using Lands.Models;
using Svg;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
namespace Lands.ViewsModels
{
    public class LandViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<Border> borders;
        private ObservableCollection<Currency> currencies;
        private ObservableCollection<Language> languages;
        #endregion

        #region Properties
        public Land Land { get; set; }
        public ObservableCollection<Border> Borders
        {
            get { return borders; }
            set { SetValue(ref this.borders, value); }
        }

        public ObservableCollection<Currency> Currencies
        {
            get { return currencies; }
            set { SetValue(ref this.currencies, value); }
        }

        public ObservableCollection<Language> Languages
        {
            get { return languages; }
            set { SetValue(ref this.languages, value); }
        }

        public string ImagePNG { get; set; }

        #endregion
        public LandViewModel(Land land)
        {
            Land = land;
            this.LoadBorders();
            this.LoadCurrencies();
            this.LoadLanguages();
        }

        #region Methods
        private void LoadBorders()
        {
            Borders = new ObservableCollection<Border>();
            foreach (var item in Land.Borders)
            {
                var item_selected = MainViewModel.GetInstance().list.Where(l => l.Alpha3Code == item).FirstOrDefault();
                Borders.Add(new Border() { Code = item_selected.Alpha3Code, Name = item_selected.Name });
            }
        }
        private void LoadCurrencies() => Currencies = new ObservableCollection<Currency>(Land.Currencies);
        private void LoadLanguages() => Languages = new ObservableCollection<Language>(Land.Languages);

        #endregion

    }
}
