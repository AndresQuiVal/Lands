using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Lands.Models;
using Xamarin.Forms;
using Lands.Views;
using System.Linq;

namespace Lands.ViewsModels
{
    public class BorderItemViewModel : Border
    {
        #region Properties
        public ICommand LandCommand
        {
            get { return new RelayCommand(ShowLand); }
        } 
        #endregion

        #region Methods
        public async void ShowLand()
        {
            var land_list = MainViewModel.GetInstance().list.Where(l => l.Alpha3Code == Code).FirstOrDefault();
            MainViewModel.GetInstance().Land = new LandViewModel(land_list);
            await Application.Current.MainPage.Navigation.PushAsync(new LandTabbedPage());
        }
        #endregion
    }
}
