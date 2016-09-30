using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodHound.Data.Entities.Crm.Table
{
    public class CrmActivityTableEntity
    {
        public string ActivityType { get; set; }
        public string Subject { get; set; }
        public string RegardingObjectIdName { get; set; }
        public string RegardingObjectTypeCode { get; set; }
        public string PriorityCodeName { get; set; }
        public string ScheduledStartDate { get; set; }
        public string ScheduledEndDate { get; set; }
        public string OwnerIdName { get; set; }
        public string InternalEmailAddress { get; set; }
        public string ActualStartDate { get; set; }
        public string ActualEndDate { get; set; }
        public int PriorityCode { get; set; }
        public string OwnerId { get; set; }
        public string RegardingObjectid { get; set; }
        public int StateCode { get; set; }
        public string StateCodeName { get; set; }
        public int StatusCode { get; set; }
        public string StatusCodeName { get; set; }
    }
}
