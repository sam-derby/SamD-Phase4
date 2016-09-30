namespace BloodHound.Data.Entities.Mxp.Detail
{
    public class MxpCustomerDetailEntity : MxpCustomerBaseEntity
    {
        public string CustomerName { get; set; }
        public string LegalName { get; set; }
        public string TradingAs { get; set; }
        public string ParentCustomer { get; set; }
        public string ChargeCustomerNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string CountryCode { get; set; }
        public string CurrencyCode { get; set; }
        public string VatReg { get; set; }
        public string CompanyReg { get; set; }
        public string ExtprSendMethod { get; set; }
        public string Sector { get; set; }
        public string Charge { get; set; }
        public int MachineCount { get; set; }
    }
}
