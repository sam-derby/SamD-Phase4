using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodHound.Core.Logging
{
    public interface ILogWriter
    {
        Task LogDebugAsync(LogType logType, params object[] logData);
        Task LogInfoAsync(LogType logType, params object[] logData);
        Task LogAuditAsync(LogType logType, string userName, params object[] logData);
        Task LogWarningAsync(LogType logType, params object[] logData);
        Task LogErrorAsync(Guid id, LogType logType, params object[] logData);
        Task LogFatalAsync(LogType logType, params object[] logData);
        Task LogUnHandledledErrorAsync(Guid id, Exception exception);
        Task EnsureDirectory();
    }


}
