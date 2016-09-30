using System;
using System.IO;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodHound.Core.Azure;
using BloodHound.Core.Configs;
using Newtonsoft.Json;

namespace BloodHound.Core.Logging
{
    public class LogWriter : ILogWriter
    {
        ConcurrentQueue<LogEntity> _logQueue;

        readonly ILogTableService _tableService;
        string path = "c:\\bloodhound\\log";

        public LogWriter(ILogTableService tableService)
        {
            _logQueue = new ConcurrentQueue<LogEntity>();
            _tableService = tableService;
        }

        async public Task LogDebugAsync(LogType logType, params object[] logData)
        {
            if (Settings.Logging.Debug)
                await WriteLogAsync(LogSeverity.Debug, logType, logData);
        }

        async public Task LogInfoAsync(LogType logType, params object[] logData)
        {
            if (Settings.Logging.Info)
                await WriteLogAsync(LogSeverity.Info, logType, logData);
        }

        async public Task LogAuditAsync(LogType logType, string userName, params object[] logData)
        {
            if (Settings.Logging.Audit)
                await WriteLogAsync(userName, LogSeverity.Audit, logType, logData);
        }

        async public Task LogWarningAsync(LogType logType, params object[] logData)
        {
            if (Settings.Logging.Warning)
                await WriteLogAsync(LogSeverity.Warning, logType, logData);
        }

        async public Task LogFatalAsync(LogType logType, params object[] logData)
        {
            await WriteLogAsync(LogSeverity.Debug, logType, logData);
        }

        async public Task LogErrorAsync(Guid id, LogType logType, params object[] logData)
        {
            var entity = new LogEntity
            {
                Severity = LogSeverity.Error.ToString(),
                LogType = LogType.UnHandledException.ToString(),
                Id = id.ToString(),
                EntryDate = DateTimeOffset.UtcNow,
                Details = JsonConvert.SerializeObject(logData)
            };

            await AddToQueue(entity);
        }

        async public Task LogUnHandledledErrorAsync(Guid id, Exception exception)
        {
            var entity = new LogEntity
            {
                Severity = LogSeverity.Error.ToString(),
                LogType = LogType.UnHandledException.ToString(),
                Id = id.ToString(),
                EntryDate = DateTimeOffset.UtcNow,
                Details = JsonConvert.SerializeObject(exception)
            };
            await AddToQueue(entity);
        }

        async Task WriteLogAsync(LogSeverity severity, LogType logType, params object[] logData)
        {
            var entity = new LogEntity
            {
                Severity = severity.ToString(),
                LogType = logType.ToString(),
                Id = Guid.NewGuid().ToString(),
                EntryDate = DateTimeOffset.UtcNow,
                Details = JsonConvert.SerializeObject(logData)
            };
            await AddToQueue(entity);
        }

        async Task WriteLogAsync(string userName, LogSeverity severity, LogType logType, params object[] logData)
        {
            var batch = new List<LogEntity>();
            var entity = new LogEntity
            {
                Severity = severity.ToString(),
                LogType = logType.ToString(),
                Id = Guid.NewGuid().ToString(),
                EntryDate = DateTimeOffset.UtcNow,
                Details = JsonConvert.SerializeObject(logData),
                UserName = userName
            };
            batch.Add(entity);
            Log(batch);
            //await AddToQueue(entity);
        }

        async Task AddToQueue(LogEntity logEntity)
        {
            _logQueue.Enqueue(logEntity);
            if (_logQueue.Count == Settings.Logging.LogQueueBufferSize)
            {
                var batch = new List<LogEntity>();
                LogEntity log = null;
                while (_logQueue.TryDequeue(out log))
                {
                    batch.Add(log);
                }
                Log(batch);
                //await _tableService.InsertBatchAsync(batch);
            }
        }

        async public Task EnsureDirectory()
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
        void Log(List<LogEntity> batch)
        {
            using (StreamWriter w = File.AppendText("c:\\bloodhound\\logs\\log.txt"))
            {
                foreach (LogEntity entity in batch)
                {
                    w.Write("\r\nLog Entry : ");
                    w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                    //w.WriteLine("  :{0}, {1}, {2}, {3}, {4}", entity.Id, entity.Details, entity.Severity, entity.LogType, string.IsNullOrEmpty(entity.UserName) ? entity.UserName : string.Empty);
                    //w.WriteLine("  :{0}, {1}, {2}, {3}", entity.Id, entity.Details, entity.Severity, entity.LogType);
                    w.WriteLine("TEST");
                    w.WriteLine("-------------------------------");
                }
            }
        }
    }
}

