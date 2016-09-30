using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodHound.Data.Entities.Mxp.Table
{
    public class MxpDeviceTableEntity
    {
        public string SerialNumber { get; set; }
        public string Item { get; set; }
        public string ItemDescription1 { get; set; }
        public string ItemDescription2 { get; set; }
        public string SystemRef { get; set; }
        public string PostCode { get; set; }
        public string SerialStatus { get; set; }
        public string SerialStatusDescription { get; set; }
        public string AltRef { get; set; }
        public int LeaseId { get; set; }
        public string MxpCustomerNumber { get; set; }
        public string OppNumber { get; set; }
        public string MxpCustomerName { get; set; }
    }
}
