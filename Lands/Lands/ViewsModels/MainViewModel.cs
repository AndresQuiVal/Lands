using Lands.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Lands.ViewsModels
{
    class MainViewModel : BaseViewModel // More important class
    {
        #region Atributes
        private ObservableCollection<MenuItemViewModel> menuItems;
        private ImageSource imageSource;
        private string userName;
        #endregion

        #region Properties
        public List<Land> list { get; set; }
        public LoginViewModel Login { get; set; }
        public LandsViewModel Lands { get; set; }
        public LandViewModel Land { get; set; }
        public RegisterViewModel Register { get; set; }
        public UserViewModel UserPage { get; set; }
        public string Token { get; set; }
        public string TokenType { get; set; }
        public UserInfo User { get; set; }
        public ObservableCollection<MenuItemViewModel> MenuItems
        {
            get { return this.menuItems; }
            set { SetValue(ref this.menuItems, value); }
        }
        #endregion

        #region MenuPage controlls
        public string UserName
        {
            get { return this.userName; }
            set { SetValue(ref this.userName, value); }
        }

        public ImageSource ImageSource
        {
            get { return this.imageSource; }
            set { SetValue(ref this.imageSource, value); }
        }
        #endregion

        #region Constructor

        public MainViewModel()
        {
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
                instance = new MainViewModel();
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
