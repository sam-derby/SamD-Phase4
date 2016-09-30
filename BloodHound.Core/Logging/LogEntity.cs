using System;
using Microsoft.WindowsAzure.Storage.Table;


namespace BloodHound.Core.Logging
{
    public class LogEntity : TableEntity
    {
        string _id;
        public string UserName { get; set; }
        public string Severity { get; set; }
        public string LogType { get; set; }
        public string Id
        {
            get { return _id; }
            set { _id = value;
                RowKey = value;
            }
        }
        public DateTimeOffset EntryDate { get; set; }
        public string Details { get; set; }
        public LogEntity()
        {
            PartitionKey = DateTime.UtcNow.Date.ToString("dd-MM-yyyy");
        }

    }
}
