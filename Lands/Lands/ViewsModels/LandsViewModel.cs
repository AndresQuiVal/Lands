using Lands.Models;
using Lands.Services;
using Lands.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Drawing;
using Xamarin.Forms;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Linq;
using Lands.Helpers;

namespace Lands.ViewsModels
{
    class LandsViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<LandItemViewModel> lands;
        private bool isRefreshing;
        private string textFilter;
        #endregion

        #region Properties
        public ObservableCollection<LandItemViewModel> Lands // Land
        {
            get { return this.lands; }
            set { SetValue(ref this.lands, value); }
        } // needs to be ObservableCollection to be in the ListControl in Xamarin

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public string TextFilter
        {
            get { return this.textFilter; }
            set {
                SetValue(ref this.textFilter, value);
                SearchMethod();
            }
        }

        public ICommand Search { get { return new RelayCommand(SearchMethod); } }
        #endregion

        #region Commands
        public ICommand RefreshCommand { get { return new RelayCommand(LoadLands); } } // ICommands = Windows.Input / RelayCommand() = MvvmLightLibs
        #endregion
        #region Constructors
        public LandsViewModel()
        {
            apiService = new ApiService(); // los servicios se instancian en el constructor de la clase!
            this.LoadLands();
        }
        #endregion

        #region Methods
        private async void LoadLands()
        {
            IsRefreshing = true;
            Response check_connectivity = await this.apiService.CheckConnection();
            if (check_connectivity.IsSuccess != false)
            {
                Response response = await this.apiService.GetList<Land>( //metodo que devuelve un dato de tipo Response con propiedades inicializadas
                    "https://restcountries.eu",
                    "/rest",
                    "/v2/all"); // string controller parameter
                if (!response.IsSuccess)
                {
                    await Application.Current.MainPage.DisplayAlert(
                        Languages.ErrorTitle,
                        response.Message,
                        Languages.AcceptButton);
                    await Application.Current.MainPage.Navigation.PopAsync();
                    IsRefreshing = false;
                    return;
                }
                MainViewModel.GetInstance().list = (List<Land>)response.Result;
                this.Lands = new ObservableCollection<LandItemViewModel>(ToLandItemViewModel());//this.ToLandItemViewModel());
                IsRefreshing = false;
                return;
            }
            await Application.Current.MainPage.DisplayAlert(
                Languages.ErrorTitle,
                Languages.ErrorDescription,
                Languages.AcceptButton);
            await Application.Current.MainPage.Navigation.PopAsync();
            IsRefreshing = false;
        }

        public void SearchMethod()
        {
            //if (string.IsNullOrEmpty(this.TextFilter))
            //    this.Lands = new ObservableCollection<Land>(this.list); //cuando se cambie la lisa se actualizaran los datos de la Listview
            //else
            //    this.Lands = new ObservableCollection<Land>(
            //        this.list.Where(l => l.Name.ToLower().Contains(this.TextFilter.ToLower()))); // lambda expression
            if (string.IsNullOrEmpty(this.TextFilter))
            {
                this.Lands = new ObservableCollection<LandItemViewModel>(ToLandItemViewModel());//this.ToLandItemViewModel());
                return;
            }
            this.Lands = new ObservableCollection<LandItemViewModel>(
                this.ToLandItemViewModel().Where(l => l.Name.ToLower().Contains(this.TextFilter.ToLower()) // lambda expression
                || l.Capital.ToLower().Contains(this.TextFilter.ToLower())));
        }

        public IEnumerable<LandItemViewModel> ToLandItemViewModel()
        {
            //Object list_object = list;
            //List<LandItemViewModel> land_list = (List<LandItemViewModel>)list_object;
            //return land_list;
            return MainViewModel.GetInstance().list.Select(l => new LandItemViewModel
            {
                Alpha2Code = l.Alpha2Code,
                Alpha3Code = l.Alpha3Code,
                AltSpellings = l.AltSpellings,
                Area = l.Area,
                Borders = l.Borders,
                CallingCodes = l.CallingCodes,
                Capital = l.Capital,
                Cioc = l.Cioc,
                Currencies = l.Currencies,
                Demonym = l.Demonym,
                Flag = l.Flag,
                Gini = l.Gini,
                Languages = l.Languages,
                Latlng = l.Latlng,
                Name = l.Name,
                NativeName = l.NativeName,
                NumericCode = l.NumericCode,
                Population = l.Population,
                Region = l.Region,
                RegionalBlocs = l.RegionalBlocs,
                Subregion = l.Subregion,
                Timezones = l.Timezones,
                TopLevelDomain = l.TopLevelDomain,
                Translations = l.Translations,
            });
        }
        #endregion

        #region Lambda Expressions
        //Func<Land, bool> get_name = _l => _l.Name.ToLower().Contains(TextFilter.ToLower());
        #endregion

        #region Services
        private ApiService apiService;
        #endregion


    }
}
