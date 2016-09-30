namespace BloodHound.Data.Entities.Crm.Table
{
    public class CrmAccountTableEntity : CrmAccountBaseEntity
    {
        public string LastActivityDate { get; set; }
        public string NextActivityDate { get; set; }
    }
}
