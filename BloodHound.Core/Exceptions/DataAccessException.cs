using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodHound.Core.Exceptions
{
    public class DataAccessException : Exception, IBloodHoundException
    {
        public Exception Exception { get; set; }
        public Guid CorrelationId { get; set; }
        public DataAccessException(Exception exception, Guid correlationId)
        {
            Exception = exception;
            CorrelationId = correlationId;
        }
    }
}
