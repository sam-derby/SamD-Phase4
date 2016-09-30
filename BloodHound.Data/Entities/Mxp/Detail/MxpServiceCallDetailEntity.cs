using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodHound.Data.Entities.Mxp.Table;

namespace BloodHound.Data.Entities.Mxp.Detail
{
    public class MxpServiceCallDetailEntity : MxpServiceCallTableEntity
    {
        public int CategoryCode { get; set; }
        public string CategoryCodeDescription { get; set; }
        public string ProblemCode { get; set; }
        public string ProblemCodeDescription { get; set; }
        public string CauseCode { get; set; }
        public string CauseCodeDescription { get; set; }
        public string RepairCode { get; set; }
        public string RepairCodeDescription { get; set; }
        public string RepairRequestDate { get; set; }
        public string RepairRequestTime { get; set; }
        public string RepairDispatchDate { get; set; }
        public string RepairDispatchTime { get; set; }
        public string RepairArrivalDate { get; set; }
        public string RepairArrivalTime { get; set; }
        public string RepairCompleteDate { get; set; }
        public string RepairCompleteTime{ get; set; }
        public string SystemRef { get; set; }

        public string FormattedRepairRequestTime => RepairRequestTime.FormattedTime();
        public string FormattedRepairDispatchTime => RepairDispatchTime.FormattedTime();
        public string FormattedRepairArrivalTime => RepairArrivalTime.FormattedTime();
        public string FormattedRepairCompleteTime => RepairCompleteTime.FormattedTime();
        public string FormattedEntryTime => EntryTime.FormattedTime();
    }
}
