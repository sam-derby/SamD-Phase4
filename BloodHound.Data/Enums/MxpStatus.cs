using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodHound.Data.Enums
{
    public enum CrmMxpStatus
    {
        ExistsCrmAndMxp = 10,
        ExistsInCrmNotInMxp = 20,
        DoesntExistInCrm = 30,
        DoesntExistInMxp = 40,
        ExistsInMxpNotInCrm = 50
    }
}
