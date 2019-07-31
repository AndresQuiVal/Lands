using Lands.Models;
using System;
using System.Collections.Generic;
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
                return new MainViewModel();
            }
            return instance;
        }
        #endregion
    }
}
