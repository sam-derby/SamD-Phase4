using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodHound.Data.Entities.Mxp.Detail;
using BloodHound.Data.Entities.Mxp.Table;
using BloodHound.Data.Interfaces;
using BloodHound.Data.Interfaces.Repositories;

namespace BloodHound.Data.Repositories.Mxp
{
    public class MxpDeviceRepository : IMxpDeviceRepository
    {
        private readonly ISQLClient _sqlclient;

        public MxpDeviceRepository(ISQLClient sqlclient)
        {
            _sqlclient = sqlclient;
        }
        async public Task<IEnumerable<MxpDeviceTableEntity>> GetTableEntitiesAsync(string custNumber = "", string sysRef = "", string serialNumber = "", string altRef = "", int? leaseId = null)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@Cust_no", SqlDbType = SqlDbType.VarChar, Value = !string.IsNullOrEmpty(custNumber) ?string.Format("%{0}%",custNumber) : null},
                new SqlParameter {ParameterName = "@systeref", SqlDbType = SqlDbType.VarChar, Value = !string.IsNullOrEmpty(sysRef) ?string.Format("%{0}%",sysRef) : null},
                new SqlParameter {ParameterName = "@serial_no", SqlDbType = SqlDbType.VarChar, Value = !string.IsNullOrEmpty(serialNumber) ?string.Format("%{0}%",serialNumber) : null},
                new SqlParameter {ParameterName = "@alt_ref", SqlDbType = SqlDbType.VarChar, Value = !string.IsNullOrEmpty(altRef) ?string.Format("%{0}%",altRef) : null},
                new SqlParameter {ParameterName = "@lease_id",SqlDbType = SqlDbType.Int, Value = leaseId}
            };

            var data = await _sqlclient.ExecuteReaderSpAsync("sharepoint.GetDeviceSummary", parameters.ToArray());

            var resultRecords = (from DataRow row in data.Rows
                                 select new MxpDeviceTableEntity
                                 {
                                     SerialNumber = row["serial_no"].ToString(),
                                     Item = row["item_no"].ToString(),
                                     ItemDescription1 = row["description##1"].ToString(),
                                     ItemDescription2 = row["description##2"].ToString(),
                                     SystemRef = row["acqsystemref"].ToString(),
                                     PostCode = row["zip_code"].ToString(),
                                     SerialStatus = row["serial_stat"].ToString(),
                                     SerialStatusDescription = row["description"].ToString(),
                                     MxpCustomerNumber = row["cust_no"].ToString(),
                                     AltRef = row["alt_ref"].ToString(),
                                     LeaseId = Convert.ToInt32(row["lease_id"].ToString()),
                                     OppNumber = row["oppno"].ToString(),
                                     MxpCustomerName = row["cust_name"].ToString()
                                 }).ToList();

            return resultRecords.OrderBy(m => m.SystemRef).ToList(); ;
        }

        async public Task<MxpDeviceDetailEntity> GetDeviceDetailAsync(string systemRef)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@acqsystemref", SqlDbType = SqlDbType.VarChar, Value = systemRef}
            };

            var data = await _sqlclient.ExecuteReaderSpAsync("sharepoint.GetDeviceDetails", parameters.ToArray());

            var resultRecords = (from DataRow row in data.Rows
                                 select new MxpDeviceDetailEntity
                                 {
                                     SerialNumber = row["serial_no"].ToString(),
                                     Item = row["item_no"].ToString(),
                                     ItemDescription1 = row["description##1"].ToString(),
                                     ItemDescription2 = row["description##2"].ToString(),
                                     SystemRef = row["acqsystemref"].ToString(),
                                     SalesOrder = Convert.ToInt32(row["reference"]),
                                     InstallDate = string.IsNullOrEmpty(row["install_date"].ToString()) ? "" : Convert.ToDateTime(row["install_date"]).ToString("dd MMM yyyy"),
                                     LastServiceDate = string.IsNullOrEmpty(row["entry_date"].ToString()) ? "" : Convert.ToDateTime(row["entry_date"]).ToString("dd MMM yyyy"),
                                     SerialStatus = row["serial_stat"].ToString(),
                                     SerialStatusDescription = row["description"].ToString(),
                                     PrimaryContact = row["primary_con"].ToString(),
                                     Telephone = row["primary_phon"].ToString(),
                                     City = row["city"].ToString(),
                                     Country = row["country"].ToString(),
                                     PostCode = row["zip_code"].ToString(),  
                                     Address1 = row["address##1"].ToString(),
                                     Address2 = row["address##2"].ToString(),
                                     Address3 = row["address##3"].ToString(),
                                     Address4 = row["address##4"].ToString(),
                                     Location1 = row["location##1"].ToString(),
                                     Location2 = row["location##2"].ToString(),
                                     LeaseRef = row["lease_ref"].ToString(),
                                     ServiceProvider = string.IsNullOrEmpty(row["servprov"].ToString()) ? "Danwood" : row["servprov"].ToString(),
                                     LeaseId = Convert.ToInt32(row["lease_id"].ToString()),
                                     LastMeterReadingDate = string.IsNullOrEmpty(row["last_rd_date"].ToString()) ? "" : Convert.ToDateTime(row["last_rd_date"]).ToString("dd MMM yyyy"),
                                     NextMeterReadingDueDate = string.IsNullOrEmpty(row["next_meter_dt"].ToString()) ? "" : Convert.ToDateTime(row["next_meter_dt"]).ToString("dd MMM yyyy"),
                                     ContractNumber = row["contract_no"].ToString(),
                                     LineNumber = row["line_no"].ToString(),
                                     MxpCustomerNumber = row["cust_no"].ToString(),
                                     OppNumber = row["oppno"].ToString(),
                                     MxpCustomerName = row["cust_name"].ToString()
                                 }).ToList();

            return resultRecords.FirstOrDefault();
        }
    }
}
