using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodHound.Data.Entities.Mxp.Table;

namespace BloodHound.Data.Entities.Mxp.Detail
{
    public class MxpCustomerContactDetailEntity : MxpCustomerContactTableEntity
    {
        public string Fax { get; set; }
        public string EmailAddress { get; set; }
        public string Notes { get; set; }
    }
}
