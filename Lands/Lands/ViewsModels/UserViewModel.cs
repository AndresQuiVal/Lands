using GalaSoft.MvvmLight.Command;
using Lands.Helpers;
using Lands.Models;
using Lands.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lands.ViewsModels
{
    public class UserViewModel : BaseViewModel
    {
        #region Services
        ApiService apiService;
        #endregion

        #region Constructors
        public UserViewModel(UserInfo user)
        {
            apiService = new ApiService();
            localUser = user;
            MainViewModel.GetInstance().MasterPage.IsPresented = false;
            this.LoadUserContent();
        }
        #endregion

        #region Properties
        public ImageSource ImageSource
        {
            get { return this.imageSource; }
            set { SetValue(ref this.imageSource, value); }
        }
        public string FullName
        {
            get { return this.fullName; }
            set { SetValue(ref this.fullName, value); }
        }
        public string FirstName
        {
            get { return this.firstName; }
            set { SetValue(ref this.firstName, value); }
        }
        public string LastName
        {
            get { return this.lastName; }
            set { SetValue(ref this.lastName, value); }
        }
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set { SetValue(ref this.phoneNumber, value); }
        }
        #endregion

        #region Attributes
        private ImageSource imageSource;
        private UserInfo localUser;
        private string fullName;
        private string firstName;
        private string lastName;
        private string email;
        private string phoneNumber;
        private MediaFile file;
        #endregion

        #region Methods
        public void LoadUserContent()
        {
            if (localUser.ImagePath == null)
                ImageSource = "cameraImage";
            else
                ImageSource = localUser.ImageFullPath;

            FullName = localUser.FullName;
            FirstName = localUser.FirstName;
            LastName = localUser.LastName;
            Email = localUser.Email;
            PhoneNumber = localUser.Telephone;
        }

        public async void ChangeImage()
        {
            await CrossMedia.Current.Initialize();
            if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsPickPhotoSupported)
            {
                string actionSheetResponse = await Application.Current.MainPage.DisplayActionSheet(
                    Languages.QuestionActionSheet,
                    Languages.CancelTextButton,
                    null,
                    Languages.GalleryTextButton,
                    Languages.PhotoTextButton);

                if (actionSheetResponse != Languages.CancelTextButton)
                {
                    if (actionSheetResponse != Languages.GalleryTextButton)
                    {
                        this.file = await CrossMedia.Current.TakePhotoAsync(
                         new StoreCameraMediaOptions
                         {
                             Directory = "Sample", //<---- Directory name
                             Name = "test.png",
                             PhotoSize = PhotoSize.Small
                         });
                    }
                    else
                    {
                        this.file = await CrossMedia.Current.PickPhotoAsync(); //<-- doesnt take params
                    }

                    if (this.file != null)
                    {
                        this.ImageSource = ImageSource.FromStream(() =>
                        {
                            var stream = file.GetStream();
                            return stream;
                        });
                    }
                } else
                    return;
            }
        }
        #endregion

        #region Commands
        public ICommand ChangeImageCommand
        {
            get { return new RelayCommand(this.ChangeImage); }
        }
        #endregion
    }
}
