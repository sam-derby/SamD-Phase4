using System;
using System.Configuration;

namespace BloodHound.Core
{
    public static class Settings
    {
        public static class Database
        {
            public static string ConnectionString => ConfigurationManager.ConnectionStrings["MXPTransferDevConnectionString"].ConnectionString;
        }

        public static class Cache
        {
            public static int Duration => Convert.ToInt32(ConfigurationManager.AppSettings["Cache-Duration-In-Seconds"]);
            public static bool EnableCache => Convert.ToBoolean(ConfigurationManager.AppSettings["Enable-Cache"]);
        }

        public static class Security
        {
            public static bool ApplyGroupCheck => Convert.ToBoolean(ConfigurationManager.AppSettings["Apply-Group-Check"]);
        }

        public static class Logging
        {
            public static bool Debug => Convert.ToBoolean(ConfigurationManager.AppSettings["log-debug"]);
            public static bool Info => Convert.ToBoolean(ConfigurationManager.AppSettings["log-info"]);
            public static bool Warning => Convert.ToBoolean(ConfigurationManager.AppSettings["log-warning"]);
            public static bool Audit => Convert.ToBoolean(ConfigurationManager.AppSettings["log-audit"]);

            public static int LogQueueBufferSize => Convert.ToInt32(ConfigurationManager.AppSettings["log-queue-buffer-size"]);
        }

        public static class Azure
        {
            public static string StorageAccountConnectionString => ConfigurationManager.AppSettings["AzureStorageConnectionString"];
            public static string LogTableName => ConfigurationManager.AppSettings["Log-Table-Name"];
        }

        public static class ViewNames
        {
            public static string ForbiddenView => ConfigurationManager.AppSettings["ForbiddenView"];
        }
    }
}