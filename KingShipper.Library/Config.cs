using System;
using System.Configuration;
using System.IO;

namespace KingShipper.Library
{
    public class Config
    {
        public static string GetAppSettingFromConfig(string key)
        {
            //var keyListInConfig = ConfigurationManager.AppSettings[key];
            return ConfigurationManager.AppSettings[key];
        }

        public static string GetConnectionStringFromConfig(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }

        public static string LogErrorFolder
        {
            get
            {
                var result = GetAppSettingFromConfig("LogErrorFolder");
                return !String.IsNullOrEmpty(result) ? result : Directory.GetCurrentDirectory();
            }
        }
        public static string AlowDomain
        {
            get { return GetAppSettingFromConfig("AlowDomain"); }
        }
        public static string DebugPath
        {
            get { return GetAppSettingFromConfig("DebugPath"); }
        }

        public static string ErroPath
        {
            get { return GetAppSettingFromConfig("ErroPath"); }
        }

        public static string WebApiUrl
        {
            get { return GetAppSettingFromConfig("WebApiUrl"); }
        }
    }
}
