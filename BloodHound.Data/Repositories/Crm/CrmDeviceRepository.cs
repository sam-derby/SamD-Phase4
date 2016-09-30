using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodHound.Data.Entities.Crm.Detail;
using BloodHound.Data.Entities.Crm.Table;
using BloodHound.Data.Interfaces;
using BloodHound.Data.Interfaces.Repositories;

namespace BloodHound.Data.Repositories.Crm
{
    public class CrmDeviceRepository : ICrmDeviceRepository
    {
        private readonly ISQLClient _sqlclient;

        public CrmDeviceRepository(ISQLClient sqlclient)
        {
            _sqlclient = sqlclient;
        }
        async public Task<IEnumerable<CrmDeviceTableEntity>> GetTableEntitiesAsync(Guid accountNumber)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@accountid",SqlDbType = SqlDbType.UniqueIdentifier, Value = accountNumber}
            };

            var data = await _sqlclient.ExecuteReaderSpAsync("sharepoint.GetCRMDeviceSummary", parameters.ToArray());

            var resultRecords = (from DataRow row in data.Rows
                                 select new CrmDeviceTableEntity
                                 {
                                     SerialNumber = row["dw_serial_no"].ToString(),
                                     ItemNumber = row["dw_item_no"].ToString(),
                                     Name = row["dw_name"].ToString(),
                                     ParentAccountName = row["dw_parentaccountidname"].ToString(),
                                     ParentAccountId = row["dw_parentaccountid"].ToString(),
                                     OwnerId = row["ownerid"].ToString(),
                                     Owner = row["owneridname"].ToString(),
                                     DeviceMifId = row["dw_devicemifid"].ToString(),
                                     SystemRef = row["dw_systemref"].ToString()
                                 }).ToList();

            return resultRecords.OrderBy(m => m.SystemRef).ToList();
        }

        async public Task<CrmDeviceDetailEntity> GetDeviceDetailAsync(Guid deviceId)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@deviceid", SqlDbType = SqlDbType.UniqueIdentifier, Value = deviceId}
            };

            var data = await _sqlclient.ExecuteReaderSpAsync("sharepoint.GetCRMDeviceDetails", parameters.ToArray());

            return ProcessDetailsResults(data).FirstOrDefault();
        }

        async public Task<CrmDeviceDetailEntity> GetDeviceDetailBySysRefAsync(string sysRef)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@accountid", SqlDbType = SqlDbType.UniqueIdentifier, Value = null},
                new SqlParameter {ParameterName = "@deviceid", SqlDbType = SqlDbType.UniqueIdentifier, Value = null},
                new SqlParameter {ParameterName = "@systemref", SqlDbType = SqlDbType.VarChar, Value = sysRef}
            };

            var data = await _sqlclient.ExecuteReaderSpAsync("sharepoint.GetCRMDeviceDetails", parameters.ToArray());

            return ProcessDetailsResults(data).FirstOrDefault();
        }

        IEnumerable<CrmDeviceDetailEntity> ProcessDetailsResults(DataTable dataTable)
        {
            var resultRecords = (from DataRow row in dataTable.Rows
                                 select new CrmDeviceDetailEntity
                                 {
                                     SerialNumber = row["dw_serial_no"].ToString(),
                                     ItemNumber = row["dw_item_no"].ToString(),
                                     SytemRef = row["dw_systemref"].ToString(),
                                     ParentAccountName = row["dw_parentaccountidname"].ToString(),
                                     ParentAccountId = row["dw_parentaccountid"].ToString(),
                                     OwnerId = row["ownerid"].ToString(),
                                     Owner = row["owneridname"].ToString(),
                                     DeviceMifId = row["dw_devicemifid"].ToString(),
                                     Company = row["img_mxpcompanyname"].ToString(),
                                     Location = row["img_mxplocation"].ToString(),
                                     Address = row["img_mxpaddress"].ToString(),
                                     City = row["img_mxpcity"].ToString(),
                                     PostCode = row["img_mxppostcode"].ToString(),
                                     CustomerNumber = row["img_mxpgrpcustid"].ToString(),
                                 }).ToList();
            return resultRecords;
        }
    }
}
