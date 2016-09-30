using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodHound.Data.Entities.Mxp.Table
{
    public class MxpServiceCallTableEntity
    {
        public string ServiceNumber { get; set; }
        public string EntryDate { get; set; }
        public string EntryTime { get; set; }
        public string SoStatus { get; set; }
        public string SoStatusDescription { get; set; }
        public string SerialNumber { get; set; }
        public string ItemNumber { get; set; }
        public string TechCode { get; set; }
        public string TechName { get; set; }
        public string CustomerNumber { get; set; }
        public string ChargeCustomerNumber { get; set; }
        public string ContractNumber { get; set; }
        public int ContractLine { get; set; }
        public string ServiceType { get; set; }
    }
}
