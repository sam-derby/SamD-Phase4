namespace BloodHound.Data.Entities.Mxp.Table
{
    public class MxpCustomerContactTableEntity : MxpCustomerBaseEntity
    {
        public string ChargeCustomer { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
