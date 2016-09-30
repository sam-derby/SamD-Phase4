using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodHound.Core.Configs
{
    public interface ITableConfig
    {
        string TableName { get;}
        string StorageAccountConnectionString { get; }
    }
}
