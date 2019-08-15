using Lands.Interfaces;
using Lands.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Lands.Helpers
{
    public static class Languages
    {
        static Languages()
        {
            CultureInfo ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        #region Language properties
        public static string ErrorTitle { get { return Resource.ErrorTitle; } }
        public static string ErrorDescription { get { return Resource.ErrorDescription; } }
        public static string AcceptButton { get { return Resource.AcceptButton; } }
        public static string ErrorUhandledDescription { get { return Resource.ErrorUnhandledDescription; } }
        public static string ErrorInternetDescrption { get { return Resource.ErrorInternetDescription; } }
        public static string PasswordText { get { return Resource.PasswordText; } }
        public static string EmailPlaceHolder { get { return Resource.EmailPlaceHolder; } }
        public static string PasswordPlaceHolder { get { return Resource.PasswordPlaceHolder; } }
        public static string ForgotYourPassword { get { return Resource.ForgotYourPassword; } }
        public static string LoginTextButton { get { return Resource.LoginTextButton; } }
        public static string RegisterTextButton { get { return Resource.RegisterTextButton; } }
        public static string RememberMe { get { return Resource.RememberMe; } }
        public static string SearchLandPlaceHolder { get { return Resource.SearchLandPlaceHolder; } }
        public static string CapitalText { get { return Resource.CapitalText; } }
        public static string PopulationRangeText { get { return Resource.PopulationRangeText; } }
        public static string AreaText { get { return Resource.AreaText; } }
        public static string AlphaCode2Text { get { return Resource.AlphaCode2Text; } }
        public static string AlphaCode3Text { get { return Resource.AlphaCode3Text; } }
        public static string RegionText { get { return Resource.RegionText; } }
        public static string SubRegionText { get { return Resource.SubRegionText; } }
        public static string DenonymText { get { return Resource.DenonymText; } }
        public static string GiniText { get { return Resource.GiniText; } }
        public static string NativeNameText { get { return Resource.NativeNameText; } }
        public static string NumericCodeText { get { return Resource.NumericCodeText; } }
        public static string CiocText { get { return Resource.CiocText; } }
        public static string GermanTranslation { get { return Resource.GermanTranslation; } }
        public static string SpanishTranslation { get { return Resource.SpanishTranslation; } }
        public static string FrenchTranslation { get { return Resource.FrenchTranslation; } }
        public static string JapaneseTranslation { get { return Resource.JapaneseTranslation; } }
        public static string ItalianTranslation { get { return Resource.ItalianTranslation; } }
        public static string BrasilianTranslation { get { return Resource.BrasilianTranslation; } }
        public static string PortugeseTranslation { get { return Resource.PortugeseTranslation; } }
        public static string DutchTranslation { get { return Resource.DutchTranslation; } }
        public static string CroatianTranslation { get { return Resource.CroatianTranslation; } }
        public static string DanishTranslation { get { return Resource.DanishTranslation; } }
        public static string GeneralTabbedText { get { return Resource.GeneralTabbedText; } }
        public static string BorderTabbedText { get { return Resource.BorderTabbedText; } }
        public static string CurrenciesTabbedText { get { return Resource.CurrenciesTabbedText; } }
        public static string TranslationsTabbedText { get { return Resource.TranslationsTabbedText; } }
        public static string LanguageTabbedText { get { return Resource.LanguagesTabbedText; } }
        public static string CancelTextButton { get { return Resource.CancelTextButton; } }
        public static string QuestionActionSheet { get { return Resource.QuestionActionSheet; } }
        public static string GalleryTextButton { get { return Resource.GalleryTextButton; } }
        public static string PhotoTextButton { get { return Resource.PhotoTextButton; } }
        #endregion       
    }
}
