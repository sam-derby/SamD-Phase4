using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodHound.Data.Entities.Crm.Detail
{
    public class CrmAccountDetailEntity : CrmAccountBaseEntity
    {
        public string PatchId { get; set; }
        public string CustomerSector { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string PrimarySalesContact { get; set; }
        public string PrimaryServiceContact { get; set; }
        public string Email { get; set; }
        public string BusinessPhone { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Street3 { get; set; }
        public string CountryRegion { get; set; }
        public string Country { get; set; }
        public string PrimaryContactId { get; set; }
        public string PrimaryGeneralContactId { get; set; }
        public string CrmSharepointId { get; set; }
        public string CrmSharepointUrl { get; set; }
    }
}
