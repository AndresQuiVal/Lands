using GalaSoft.MvvmLight.Command;
using Lands.Helpers;
using Lands.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lands.ViewsModels
{
    public class MenuItemViewModel : BaseViewModel
    {
        #region Attributes
        private string userName;
        #endregion

        #region Constructors
        //public MenuItemViewModel()
        //{
        //    UserName = string.Format("Hello {0}", MainViewModel.GetInstance().User.FirstName); // ERROR OVER THIS LINE
        //}
        #endregion

        #region Properties
        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }
        //public string UserName
        //{
        //    get { return this.userName; }
        //    set { SetValue(ref this.userName, value); }
        //}
        #endregion

        #region Commands
        public ICommand NavigationCommand
        {
            get { return new RelayCommand(this.Navigation); }
        }
        #endregion

        #region Methods
        public async void Navigation()
        {
            if (this.PageName == "LoginPage")
            {
                MainViewModel.GetInstance().Login.Email = "";
                MainViewModel.GetInstance().Login.Password = "";
                Settings.Token = string.Empty;
                Settings.TokenType = string.Empty;
                Settings.UserID = string.Empty;
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
            else if (this.PageName == "AccountPage")
            {
                var user = MainViewModel.GetInstance().User;
                MainViewModel.GetInstance().UserPage = new UserViewModel(user);
                await App.Navigator.PushAsync(new UserPage());
            }
        }
        #endregion
    }
}
