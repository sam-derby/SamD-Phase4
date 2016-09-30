namespace BloodHound.Data.Entities.Crm
{
    public class CrmAccountBaseEntity
    {
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string OwnerName { get; set; }
        public string OwnerId { get; set; }
        public string OwnerEmailAddress { get; set; }
        public string ParentAccountId { get; set; }
        public string ParentAccountName { get; set; }
        public string ActiveDeviceCount { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string MxpCustomerNumber { get; set; }
    }
}
