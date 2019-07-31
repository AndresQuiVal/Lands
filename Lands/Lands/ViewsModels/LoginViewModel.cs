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
    #endregion

    class LoginViewModel : BaseViewModel // Class that with allow us to change the value of the props in execution time of the app
    {
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
            IsEnabled = true;
        }
        #endregion

        #region Methods
        private async void LoginMethod()
        {
            this.IsRunning = true;
            this.IsEnabled = false;
            if (Email != "andres.quirozv14@gmail.com" || Password != "Valdovinos15")
            {
                this.Email = string.Empty;
                this.Password = string.Empty;
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You've entered an invalid token",
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
