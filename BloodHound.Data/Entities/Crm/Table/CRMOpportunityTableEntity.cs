using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodHound.Data.Entities.Crm.Table
{
    public class CrmOpportunityTableEntity
    {
        public string OpportunityNumber { get; set; }
        public string Topic { get; set; }
        public string PotentialCustomerName { get; set; }
        public string StatusCodeName { get; set; }
        public string OwnerIdName { get; set; }
        public string OwnerEmailAddress { get; set; }
        public string CustomerId { get; set; }
        public string OpportunityId { get; set; }
        public string OwnerId { get; set; }
        public int StateCode { get; set; }
        public string StateCodeName { get; set; }
        public int StatusCode { get; set; }
        public string EstimatedCloseDate { get; set; }
        public string ActualCloseDate { get; set; }

    }
}
