using GalaSoft.MvvmLight.Command;
using Lands.Models;
using Lands.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lands.ViewsModels
{
    class LandItemViewModel : Land // current class inherits from Land Model (model that contains all the Properties for the API being formated into C# code)
    {
        #region Properties
        public ICommand SelectLandCommand
        {
            get { return new RelayCommand(SelectedLand); }
        }
        #endregion

        #region Methods
        public async void SelectedLand()
        {
            MainViewModel.GetInstance().Land = new LandViewModel(this);
            await App.Navigator.PushAsync(new LandTabbedPage());
        }
        #endregion

    }
}
