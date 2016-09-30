using System;
using BloodHound.Data.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BloodHound.Core.MockData;
using Newtonsoft.Json;

namespace BloodHound.Data
{
    public class SQLClient : ISQLClient
    {
        readonly string _connectionString;

        public SQLClient(string connectionString)
        {
            _connectionString = connectionString;
        }
        async public Task<DataTable> ExecuteReaderSpAsync(string storedProcedure, SqlParameter[] parametersCollection)
        {
            var dataTable = new DataTable();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = storedProcedure;
                    command.Parameters.AddRange(parametersCollection);
                    var reader = await command.ExecuteReaderAsync();
                    dataTable.Load(reader);
                }
            }
            return dataTable;
        }
    }

    public class MockSQLClient : ISQLClient
    {
        async public Task<DataTable> ExecuteReaderSpAsync(string storedProcedure, SqlParameter[] parametersCollection)
        {
            DataTable dataTable = null;
            await Task.Run(() =>
            {
                var json = MockData.StoredProcedures[storedProcedure];
                dataTable = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
            });
            return dataTable;
        }
    }
}
