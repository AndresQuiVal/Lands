using GalaSoft.MvvmLight.Command;
using Lands.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lands.ViewsModels
{
    public class MenuItemViewModel
    {
        #region Properties
        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }
        #endregion

        #region Commands
        public ICommand NavigationCommand
        {
            get { return new RelayCommand(this.Navigation); }
        }
        #endregion

        #region Methods
        public void Navigation()
        {
            if (this.PageName == "LoginPage")
            {
                MainViewModel.GetInstance().Login.Email = "";
                MainViewModel.GetInstance().Login.Password = "";
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
        }
        #endregion
    }
}
