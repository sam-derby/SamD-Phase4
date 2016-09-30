using System;
using BloodHound.Data.Enums;

namespace BloodHound.Data.Entities.Mxp.Detail
{
    public class MxpDeviceDetailEntity
    {
        public string SerialNumber { get; set; }
        public string Item { get; set; }
        public string ItemDescription1 { get; set; }
        public string ItemDescription2 { get; set; }
        public string SystemRef { get; set; }
        public string InstallDate { get; set; }
        public int SalesOrder { get; set; }
        public string LastServiceDate { get; set; }
        public string SerialStatusDescription { get; set; }
        public string SerialStatus { get; set; }
        public string PrimaryContact { get; set; }
        public string Telephone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string ServiceProvider { get; set; }
        public int LeaseId { get; set; }
        public string Owner { get; set; }
        public string LastMeterReadingDate { get; set; }
        public string NextMeterReadingDueDate { get; set; }
        public string ContractNumber { get; set; }
        public string LineNumber { get; set; }
        public string MxpCustomerNumber { get; set; }
        public string OppNumber { get; set; }
        public string MxpCustomerName { get; set; }
        public string LeaseRef { get; set; }
        public string Location1 { get; set; }
        public string Location2 { get; set; }

        public CrmMxpStatus CrmMxpStatus { get; set; }
        public int DaysUntilNextReadingDate
        {
            get
            {
                if (!string.IsNullOrEmpty(NextMeterReadingDueDate))
                {
                    var spanInDays = (Convert.ToDateTime(NextMeterReadingDueDate) - DateTime.Now).TotalDays;
                    return Convert.ToInt32(spanInDays);
                }
                return 0;
            }
        }

    }
}