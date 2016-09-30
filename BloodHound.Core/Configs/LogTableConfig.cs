using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodHound.Core.Configs
{
    public class LogTableConfig : ITableConfig
    {
        public string TableName => Settings.Azure.LogTableName;
        public string StorageAccountConnectionString => Settings.Azure.StorageAccountConnectionString;
    }
}
