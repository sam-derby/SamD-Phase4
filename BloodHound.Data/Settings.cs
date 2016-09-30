using System.Configuration;

namespace BloodHound.Data
{
    public static class Settings
    {
        public static string CrmConnectionString => ConfigurationManager.AppSettings["CrmConnectionString"];
    }
}
