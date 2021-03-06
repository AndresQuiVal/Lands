﻿using GalaSoft.MvvmLight.Command;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Lands.Services;
using Xamarin.Forms;
using Plugin.Media;
using Lands.Helpers;
using Lands.Models;

namespace Lands.ViewsModels
{
    public class RegisterViewModel : BaseViewModel
    {
        #region Services
        ApiService apiService;
        #endregion

        #region Attributes
        private bool isRunning;
        private string name;
        private string lastname;
        private string email;
        private string phone;
        private string password;
        private string confirmPassword;
        private bool isEnabled;
        private ImageSource imageSource;
        private MediaFile file;
        #endregion

        #region Constructors
        public RegisterViewModel()
        {
            this.apiService = new ApiService();
            ImageSource = "cameraImage";
            IsEnabled = true;
        }
        #endregion

        #region Properties
        public ImageSource ImageSource
        {
            get { return this.imageSource; }
            set { SetValue(ref this.imageSource, value); }
        }
        public string Name
        {
            get { return this.name; }
            set { SetValue(ref this.name, value); }
        }
        public string LastName
        {
            get { return this.lastname; }
            set { SetValue(ref this.lastname, value); }
        }
        public string Email
        {
            get { return this.email; ; }
            set { SetValue(ref this.email, value); }
        }
        public string Phone
        {
            get { return this.phone; }
            set { SetValue(ref this.phone, value); }
        }
        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }
        public string ConfirmPassword
        {
            get { return this.confirmPassword; }
            set { SetValue(ref this.confirmPassword, value); }
        }
        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Commands
        public ICommand ChangeImageCommand
        {
            get { return new RelayCommand(this.ChangeImage); }
        }
        public ICommand RegisterCommand
        {
            get { return new RelayCommand(this.Register); }
        }
        #endregion

        #region Methods
        public async void ChangeImage()
        {
            await CrossMedia.Current.Initialize();

            if (CrossMedia.Current.IsCameraAvailable &&
                CrossMedia.Current.IsTakePhotoSupported)
            {
                string source = await Application.Current.MainPage.DisplayActionSheet(
                    Languages.QuestionActionSheet,
                    Languages.CancelTextButton,
                    null,
                    Languages.GalleryTextButton,
                    Languages.PhotoTextButton);

                if (source == Languages.CancelTextButton)
                {
                    this.file = null;
                    return;
                }

                if (source == Languages.PhotoTextButton)
                {
                    this.file = await CrossMedia.Current.TakePhotoAsync(
                        new StoreCameraMediaOptions
                        {
                            Directory = "Sample",
                            Name = "test.jpg",
                            PhotoSize = PhotoSize.Small,
                        }
                    );
                }
                else
                {
                    this.file = await CrossMedia.Current.PickPhotoAsync();
                }
            }
            else
            {
                this.file = await CrossMedia.Current.PickPhotoAsync();
            }

            if (this.file != null)
            {
                this.ImageSource = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
            }
        }

        public async void Register()
        {
            if (string.IsNullOrEmpty(this.Name) || string.IsNullOrEmpty(this.LastName) || string.IsNullOrEmpty(this.Email)
                || string.IsNullOrEmpty(this.Phone) || string.IsNullOrEmpty(this.Password) 
                || string.IsNullOrEmpty(this.ConfirmPassword))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.ErrorTitle,
                    "Empty fields aren't valid",
                    Languages.AcceptButton);
                return;
            }

            if (!RegexUtilities.IsValidEmailAddress(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.ErrorTitle,
                    "The email is not valid",
                    Languages.AcceptButton);
                return;
            }

            if (this.Password.Length < 6)
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.ErrorTitle,
                    "The password length must be more than 6 characters",
                    Languages.AcceptButton);
                return;
            }

            if (this.Password != this.ConfirmPassword)
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.ErrorTitle,
                    "The password doens't match with the confirm one",
                    Languages.AcceptButton);
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            var checkConnetion = await this.apiService.CheckConnection();
            if (!checkConnetion.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.ErrorTitle,
                    checkConnetion.Message,
                    Languages.AcceptButton);
                return;
            }

            byte[] imageArray = null;
            if (this.file != null)
            {
                imageArray = FilesHelper.ReadFully(this.file.GetStream());
            }

            var user = new UserInfo
            {
                Email = this.Email,
                FirstName = this.Name,
                LastName = this.LastName,
                Telephone = this.Phone,
                //ImageArray = imageArray,
                UserTypeId = 1,
                //Password = this.Password,
            };

            var response = await this.apiService.Post(
                "https://landsapi1.azurewebsites.net",
                "/api",
                "/Users",
                user);

            if (!response.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.ErrorTitle,
                    response.Message,
                    Languages.AcceptButton);
                return;
            }

            this.IsRunning = false;
            this.IsEnabled = true;

            await Application.Current.MainPage.DisplayAlert(
                "Succes",
                "The User has been registered",
                "Accept");
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        #endregion
    }
}
