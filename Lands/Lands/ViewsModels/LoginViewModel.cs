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
    using Lands.Helpers;
    using System.Linq;
    using Plugin.LocalNotifications;
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

        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(RegisterMethod);
            }
        } // property that references the Command for the specific Button

        public ICommand LocalNotificationCommand
        {
            get
            {
                return new RelayCommand(SendNotification);
            }
        }
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
                    Languages.ErrorTitle,
                    internet_connection.Message,
                    Languages.AcceptButton);
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
                    Languages.ErrorTitle,
                    Languages.ErrorUhandledDescription,
                    Languages.AcceptButton);
                return;
            }

            if (token.AccessToken == null)
            {
                this.Password = "";
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.ErrorTitle,
                    token.ErrorDescription,
                    Languages.AcceptButton);
                return;
            }
            Response responseUsersList = await apiService.GetList<UserInfo>(
                "https://landsapi1.azurewebsites.net",
                "/api",
                "/Users");

            if (!responseUsersList.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.ErrorTitle,
                    responseUsersList.Message,
                    Languages.AcceptButton);
                return;
            }
            List<UserInfo> listUsers = (List<UserInfo>)responseUsersList.Result;
            var user = listUsers.Where(u => u.Email == this.Email).FirstOrDefault();
            if (this.IsRemembered)
            {
                Settings.Token = token.AccessToken;
                Settings.TokenType = token.TokenType;
                Settings.UserID = user.UserId.ToString();
            }
            MainViewModel.GetInstance().User = user;//user;
            MainViewModel.GetInstance().Token = token.AccessToken;
            MainViewModel.GetInstance().TokenType = token.TokenType;
            this.IsRunning = false;
            this.IsEnabled = true;
            //var menuItem = new MenuItemViewModel()
            //{
            //    UserName = user.FirstName

            var Main = MainViewModel.GetInstance();
            Main.LoadMenuItems();
            Main.UserName = string.Format("Hola {0}", user.FirstName);
            Main.ImageSource = user.ImageFullPath;
            if (user.ImageFullPath == "noimage")
            {
                Main.ImageSource = "cameraImage";
            }
            Main.Lands = new LandsViewModel();
            var masterPage = new MasterPage();
            MainViewModel.GetInstance().MasterPage = masterPage;
            Application.Current.MainPage = masterPage;
        }

        public async void RegisterMethod()
        {
            MainViewModel.GetInstance().Register = new RegisterViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }

        public void SendNotification()
        {
            CrossLocalNotifications.Current.Show("title", "body", 101, DateTime.Now.AddSeconds(5));
        }
        #endregion
    }
}
