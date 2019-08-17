using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Lands.Helpers;
using Lands.Views;
using Lands.ViewsModels;
using Lands.Services;
using Lands.Models;

namespace Lands
{
    public partial class App : Application
    {
        ApiService apiService;
        public static NavigationPage Navigator { get; internal set; }

        public App()
        {
            InitializeComponent();
            if (String.IsNullOrEmpty(Settings.Token))
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainViewModel.GetInstance().Token = Settings.Token;
                MainViewModel.GetInstance().TokenType = Settings.TokenType;
                MainViewModel.GetInstance().Lands = new LandsViewModel();
                this.LoadUser();
                MainPage = new MasterPage();
            }
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public async void LoadUser()
        {
            apiService = new ApiService();
            var response = await apiService.CheckConnection();
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.ErrorTitle,
                    response.Message,
                    Languages.AcceptButton);
                return;
            }
            var getResponse = await apiService.Get<UserInfo>(
                "http://landsapi1.azurewebsites.net",
                "/api/User",
                string.Format("/{0}", Settings.UserID.ToString()));
            if (!getResponse.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.ErrorTitle,
                    getResponse.Message,
                    Languages.AcceptButton);
                return;
            }
            var user = (UserInfo)getResponse.Result;
            MainViewModel.GetInstance().User = user;
        }
    }
}
