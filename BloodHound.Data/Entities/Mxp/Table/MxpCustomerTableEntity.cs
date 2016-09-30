namespace BloodHound.Data.Entities.Mxp.Table
{
    public class MxpCustomerTableEntity : MxpCustomerBaseEntity
    {
        public string CustomerName { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Charge { get; set; }
        public int MachineCount { get; set; }
        public string ChargeCustomerNumber { get; set; }
    }
}
