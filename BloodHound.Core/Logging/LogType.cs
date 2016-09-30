using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodHound.Core.Logging
{
    public enum LogType
    {
        ActionInvoked,
        UnHandledException,
        DataAccessError,
        UserApplicationStart,
        NonBloodHoundUserAccess
    }
}
