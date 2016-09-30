using System;

namespace BloodHound.Data.Entities.Mxp.Detail
{
    public class MxpContractLinesDetailEntity
    {
        public string ContractNumber { get; set; }
        public string Description { get; set; }
        public string ContractStartDate { get; set; }
        public string ContractEndDate { get; set; }
        public string LineNumber { get; set; }
        public string ItemNumber { get; set; }
        public string ItemDescription { get; set; }
        public string CustomerNumber { get; set; }
        public string SerialNumber { get; set; }
        public string ChargeCustomerNumber { get; set; }
        public string PartInclusiveEnd { get; set; }
        public string NextPriceIncreaseDate { get; set; }
        public string MaxIncrease { get; set; }

        public string FormattedMaxIncrease
        {
            get
            {
                if (!string.IsNullOrEmpty(MaxIncrease))
                {
                    var converted = (int)Convert.ToDouble(MaxIncrease);
                    return converted + " %";
                }
                return string.Empty;
            }
        }
    

    public string LeaseRef { get; set; }
        public string SystemRef { get; set; }
    }
}