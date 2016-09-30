using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodHound.Data.Entities.Crm.Table
{
    public class CrmContactTableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string ParentAccountName { get; set; }
        public string ParentCustomerId { get; set; }
        public string ContactId { get; set; }
        public string BusinessPhone { get; set; }
        public string Mobile { get; set; }
        public string JobTitle { get; set; }
    }
}
