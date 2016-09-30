using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BloodHound.Core.Exceptions
{
    public interface IBloodHoundException
    {
        Exception Exception { get; set; }

        Guid CorrelationId { get; set; }
    }
}
