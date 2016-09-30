using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodHound.Data.Entities.Mxp.Table
{
    public class MxpContractHeaderTableEntity
    {
        public string ContractNumber { get; set; }
        public string Description { get; set; }
        public int NumberOfLines { get; set; }
        public string ContractStartDate { get; set; }
        public string ContractEndDate { get; set; }
        public string CustomerNumber { get; set; }
        public string ChargeCustomerNumber { get; set; }
        public int BillCycle { get; set; }
    }
}
