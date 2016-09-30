using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodHound.Data.Entities.Crm.Table;

namespace BloodHound.Data.Entities.Crm.Detail
{
    public class CrmOpportunityDetailEntity : CrmOpportunityTableEntity
    {
        public string OpportunityTypeName { get; set; }
        public string ProcurementProcess { get; set; }
        public string EstSalesRevenue { get; set; }
        public string EstServiceRevenue { get; set; }
        public string ActualValueBase { get; set; }
        public int ImgOpportunityType { get; set; }
        public int PurchaseProcess { get; set; }
        public string DwActualBase { get; set; }
    }
}
