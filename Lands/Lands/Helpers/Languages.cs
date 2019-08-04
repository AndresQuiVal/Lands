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
        #endregion       
    }
}
