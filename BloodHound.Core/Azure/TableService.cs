using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodHound.Core.Configs;
using BloodHound.Core.Logging;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;


namespace BloodHound.Core.Azure
{
    public interface ILogTableService
    {
        void Initialise();
        Task InsertAsync(LogEntity entity);
        Task InsertBatchAsync(IEnumerable<LogEntity> entities);
    }

    public class LogTableService : ILogTableService
    {
        CloudStorageAccount _storageAccount;
        CloudTableClient _tableClient;
        CloudTable _table;

        public void Initialise()
        {
            _storageAccount = CloudStorageAccount.Parse(Settings.Azure.StorageAccountConnectionString);
            _tableClient = _storageAccount.CreateCloudTableClient();

            _table = _tableClient.GetTableReference(Settings.Azure.LogTableName);
            //_table.CreateIfNotExists();
        }

        public Task InsertAsync(LogEntity entity)
        {
            var insertOperation = TableOperation.Insert(entity);
            return _table.ExecuteAsync(insertOperation);
        }

        public Task InsertBatchAsync(IEnumerable<LogEntity> entities)
        {
            var batchOperation = new TableBatchOperation();
            foreach (var entity in entities)
            {
                batchOperation.Insert(entity);
            }
          
            return _table.ExecuteBatchAsync(batchOperation);
        }
    }
}
