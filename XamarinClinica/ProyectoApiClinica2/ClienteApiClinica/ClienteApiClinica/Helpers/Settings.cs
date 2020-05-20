using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteApiClinica.Helpers
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

        public static string Username
        {
            get
            {
                return AppSettings.GetValueOrDefault("USERNAME", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("USERNAME", value);
            }
        }

        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault("PASSWORD", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("PASSWORD", value);
            }
        }

        public static string ObtenerToken
        {
            get
            {
                return AppSettings.GetValueOrDefault("TOKEN", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("TOKEN", value);
            }
        }
        public static DateTime ObtenerExpirarToken
        {
            get
            {
                return AppSettings.GetValueOrDefault("TOKENEXPIRACION", DateTime.UtcNow);
            }
            set
            {
                AppSettings.AddOrUpdateValue("TOKENEXPIRACION", value);
            }
        }

    }
}