using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodHound.Data.Entities.Mxp.Table
{
    public class MxpLeaseTableEntity
    {
        public string LeaseRef { get; set; }
        public string Funder { get; set; }
        public int Term { get; set; }
        public string StartedDate { get; set; }
        public string CalculatedEndDate { get; set; }
        public int LeaseId { get; set; }
        public int Active { get; set; }
    }
}
