using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Lands.Helpers;
using Lands.Views;
using Lands.ViewsModels;

namespace Lands
{
    public partial class App : Application
    {
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
    }
}
