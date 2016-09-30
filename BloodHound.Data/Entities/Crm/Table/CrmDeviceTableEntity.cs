using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodHound.Data.Entities.Crm.Table
{
    public class CrmDeviceTableEntity
    {
        public string Name { get; set; }
        public string ItemNumber { get; set; }
        public string SerialNumber { get; set; }
        public string ParentAccountName { get; set; }
        public string ParentAccountId { get; set; }
        public string Owner { get; set; }
        public string OwnerId { get; set; }
        public string DeviceMifId { get; set; }
        public string SystemRef { get; set; }
    }
}
