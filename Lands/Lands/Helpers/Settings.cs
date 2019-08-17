using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Lands.Models;

namespace Lands.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
        #region Setting Constants

        private const string token = "Token";
        private const string tokenType = "TokenType";
        private const string userId = "UserID";
        private static readonly string SettingsDefault = string.Empty; // change to string.Empty

        #endregion
        public static string Token
        {
            get
            {
                return AppSettings.GetValueOrDefault(token, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(token, value);
            }
        }

        public static string TokenType
        {
            get
            {
                return AppSettings.GetValueOrDefault(tokenType, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(tokenType, value);
            }
        }

        public static string UserID
        {
            get
            {
                return AppSettings.GetValueOrDefault(userId, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(userId, value);
            }
        }
    }
}
