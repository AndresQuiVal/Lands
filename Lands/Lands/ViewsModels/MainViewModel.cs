using Lands.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Lands.ViewsModels
{
    class MainViewModel // More important class
    {
        #region Atributes

        #endregion

        #region Properties
        public List<Land> list { get; set; }
        public LoginViewModel Login { get; set; }
        public LandsViewModel Lands { get; set; }
        public LandViewModel Land { get; set; }

        public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }

        #endregion

        #region Constructor

        public MainViewModel()
        {
            this.LoadMenuItems();
            Login = new LoginViewModel();
            instance = this;
        }
        #endregion

        #region SingleTon
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion

        #region Methods
        public void LoadMenuItems()
        {
            MenuItems = new ObservableCollection<MenuItemViewModel>();
            MenuItems.Add(new MenuItemViewModel
            {
                Icon = "ic_account_circle",
                Title = "Account",
                PageName = "AccountPage"
            });
            MenuItems.Add(new MenuItemViewModel
            {
                Icon = "ic_insert_chart",
                Title = "Statistics",
                PageName = "StatsPage"
            });
            MenuItems.Add(new MenuItemViewModel
            {
                Icon = "ic_exit_to_app",
                Title = "Logout",
                PageName = "LoginPage"
            });
        }
        #endregion
    }
}
