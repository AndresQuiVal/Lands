using GalaSoft.MvvmLight.Command;
using Lands.Helpers;
using Lands.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lands.ViewsModels
{
    public class ChangePasswordViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Constructors
        public ChangePasswordViewModel()
        {
            this.apiService = new ApiService();
            IsEnabled = true;
        }
        #endregion

        #region Attributes
        private string oldPassword;
        private string newPassword;
        private string confirmPassword;
        private bool isEnabled;
        private bool isRunning;
        #endregion

        #region Properties
        public string OldPassword
        {
            get { return this.oldPassword; }
            set { SetValue(ref this.oldPassword, value); }
        }
        public string NewPassword
        {
            get { return this.newPassword; }
            set { SetValue(ref this.newPassword, value); }
        }
        public string ConfirmPassword
        {
            get { return this.confirmPassword; }
            set { SetValue(ref this.confirmPassword, value); }
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        #endregion

        #region Commands
        public ICommand ChangePasswordCommand
        {
            get { return new RelayCommand(this.ChangePassword); }
        }
        #endregion

        #region Methods
        public async void ChangePassword()
        {
            if (string.IsNullOrEmpty(OldPassword) || string.IsNullOrEmpty(NewPassword) 
                || string.IsNullOrEmpty(ConfirmPassword))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.ErrorTitle,
                    "Empty fields arent valid",
                    Languages.AcceptButton);
                return;
            }

            if (OldPassword.Length < 6)
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.ErrorTitle,
                    "The password length must be more than 6 characters",
                    Languages.AcceptButton);
                return;
            }

            if (this.NewPassword != this.ConfirmPassword)
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.ErrorTitle,
                    "The password doens't match with the confirm one",
                    Languages.AcceptButton);
                return;
            }
        }
        #endregion
    }
}
