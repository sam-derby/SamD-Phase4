namespace BloodHound.Data.Entities.Mxp.Detail
{
    public class MxpLeaseDetailEntity
    {
        public string LeaseRef { get; set; }
        public string Funder { get; set; }
        public int Term { get; set; }
        public string StartedDate { get; set; }
        public string CalculatedEndDate { get; set; }
        public int LeaseId { get; set; }
        public int Active { get; set; }
        public string Status { get; set; }
    }
}