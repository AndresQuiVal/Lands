using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.ViewsModels
{
    #region Using
    using Views;
    using System.Windows.Input;
    using Xamarin.Forms;
    using GalaSoft.MvvmLight.Command;
    using Lands.Services;
    using Models;
    #endregion

    class LoginViewModel : BaseViewModel // Class that with allow us to change the value of the props in execution time of the app
    {
        #region Services

        ApiService apiService;
        
        #endregion
        #region Private class fields
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email {
            get { return email; }
            set { SetValue(ref this.email, value); }
        }
        public string Password {
            get { return password; }
            set { SetValue(ref this.password, value); }
        }
        public bool IsRunning {
            get { return isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        public bool IsEnabled {
            get { return isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        public bool IsRemembered { get; set; }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(LoginMethod); // SIN PARENTESIS!!!  
            }
        }   /*return;// new RelayCommand(LoginMethod());}*/

        public ICommand RegisterCommand { get; } // property that references the Command for the specific Button
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            apiService = new ApiService();
            IsEnabled = true;
        }
        #endregion

        #region Methods
        private async void LoginMethod()
        {
            this.IsRunning = true;
            this.IsEnabled = false;
            Response internet_connection = await apiService.CheckConnection();
            if (!internet_connection.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    internet_connection.Message,
                    "Accept");
                return;
            }
            TokenResponse token = await apiService.GetToken(
                "https://landsapi1.azurewebsites.net",
                Email,
                Password);
            if (token == null)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Something was wrong... \ntry later please.",
                    "Accept");
                return;
            }

            if (token.AccessToken == null)
            {
                this.Password = "";
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    token.ErrorDescription,
                    "Accept");
                return;
            }
            this.IsRunning = false;
            this.IsEnabled = true;
            //await Application.Current.MainPage.DisplayAlert(
            //    "Completed",
            //    $"Welcome {Email}",
            //    "Accept");

            MainViewModel.GetInstance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
        }
        #endregion
    }
}
