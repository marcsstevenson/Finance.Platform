using System.Configuration;
using Finance.Logic.Enums;

namespace Finance.Logic.Helpers
{
    public static class ConfigurationHelper
    {
        public static SystemMode CurrentSystemMode
        {
            get
            {
                var appSettingValue = ConfigurationManager.AppSettings["SystemMode"];

                if (appSettingValue != null && appSettingValue.ToLower() == "live")
                    return SystemMode.Live;
                else
                    return SystemMode.Mocked;
            }
        }

        public static bool IsTestSite
        {
            get
            {
                var appSettingValue = ConfigurationManager.AppSettings["IsTestSite"];
                return appSettingValue != null && appSettingValue.ToLower() == "true";
            }
        }

        public static string DefaultTimeZone
        {
            get
            {
                var appSettingValue = ConfigurationManager.AppSettings["DefaultTimeZone"];

                return appSettingValue ?? "New Zealand Standard Time";
            }
        }

    }
}
