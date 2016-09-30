namespace BloodHound.Data.Entities.Crm.Table
{
    public class CrmCaseTableEntity
    {
        public string Title { get; set; }
        public int CaseTypeCode { get; set; }
        public string CaseTypeCodeName { get; set; }
        public string TicketNumber { get; set; }
        public int PriorityCode { get; set; }
        public string PriorityCodeName { get; set; }
        public string CreatedOn { get; set; }
        public string CustomerId { get; set; }
        public string CustomerIdName { get; set; }
        public int StateCode { get; set; }
        public string StateCodeName { get; set; }
        public int StatusCode { get; set; }
        public string StatusCodeName { get; set; }
    }
}
