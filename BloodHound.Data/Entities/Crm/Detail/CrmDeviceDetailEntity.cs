using BloodHound.Data.Enums;

namespace BloodHound.Data.Entities.Crm.Detail
{
    public class CrmDeviceDetailEntity
    {
        public string SytemRef { get; set; }
        public string ItemNumber { get; set; }
        public string SerialNumber { get; set; }
        public string ParentAccountName { get; set; }
        public string ParentAccountId { get; set; }
        public string Owner { get; set; }
        public string OwnerId { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string DeviceMifId { get; set; }

        public string CustomerNumber { get; set; }
        public CrmMxpStatus CrmMxpStatus { get; set; }
    }
}