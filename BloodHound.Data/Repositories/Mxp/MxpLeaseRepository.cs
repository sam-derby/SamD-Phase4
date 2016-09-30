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
    public class MxpLeaseRepository : IMxpLeaseRepository
    {
        readonly ISQLClient _sqlclient;
        public MxpLeaseRepository(ISQLClient sqlclient)
        {
            _sqlclient = sqlclient;
        }

        async public Task<IEnumerable<MxpLeaseTableEntity>> GetTableEntitiesAsync(string custNumber)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@Cust_no", SqlDbType = SqlDbType.VarChar, Value = custNumber }
            };

            var data = await _sqlclient.ExecuteReaderSpAsync("sharepoint.GetLeaseSummary", parameters.ToArray());

            var resultRecords = (from DataRow row in data.Rows
                                 select new MxpLeaseTableEntity
                                 {
                                     LeaseRef = row["lease_ref"].ToString(),
                                     Funder = row["funder"].ToString(),
                                     Term = Convert.ToInt32(row["lease_term"]),
                                     StartedDate = string.IsNullOrEmpty(row["start_date"].ToString()) ? "" : Convert.ToDateTime(row["start_date"]).ToString("dd MMM yyyy"),
                                     CalculatedEndDate = string.IsNullOrEmpty(row["calc_enddate"].ToString()) ? "" : Convert.ToDateTime(row["calc_enddate"]).ToString("dd MMM yyyy"),
                                     LeaseId = Convert.ToInt32(row["lease_id"]),
                                     Active = Convert.ToInt32(row["active"]),
                                 }).ToList();

            return resultRecords;
        }

        async public Task<IEnumerable<MxpLeaseTableEntity>> SearchTableEntitiesAsync(string leaseRef)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@lease_ref", SqlDbType = SqlDbType.VarChar, Value = string.Format("%{0}%",leaseRef) }
            };

            var data = await _sqlclient.ExecuteReaderSpAsync("sharepoint.GetLeaseSummary", parameters.ToArray());

            var resultRecords = (from DataRow row in data.Rows
                                 select new MxpLeaseTableEntity
                                 {
                                     LeaseRef = row["lease_ref"].ToString(),
                                     Funder = row["funder"].ToString(),
                                     Term = Convert.ToInt32(row["lease_term"]),
                                     StartedDate = string.IsNullOrEmpty(row["start_date"].ToString()) ? "" : Convert.ToDateTime(row["start_date"]).ToString("dd MMM yyyy"),
                                     CalculatedEndDate = string.IsNullOrEmpty(row["calc_enddate"].ToString()) ? "" : Convert.ToDateTime(row["calc_enddate"]).ToString("dd MMM yyyy"),
                                     LeaseId = Convert.ToInt32(row["lease_id"]),
                                     Active = Convert.ToInt32(row["active"]),
                                 }).ToList();

            return resultRecords;
        }

        async public Task<MxpLeaseDetailEntity> GetDetailEntitieAsync(int leaseId)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@lease_id", SqlDbType = SqlDbType.Int, Value = leaseId }
            };

            var data = await _sqlclient.ExecuteReaderSpAsync("sharepoint.GetLeaseDetails", parameters.ToArray());

            var resultRecords = (from DataRow row in data.Rows
                                 select new MxpLeaseDetailEntity
                                 {
                                     LeaseRef = row["lease_ref"].ToString(),
                                     Funder = row["funder"].ToString(),
                                     Term = Convert.ToInt32(row["lease_term"]),
                                     StartedDate = string.IsNullOrEmpty(row["start_date"].ToString()) ? "" : Convert.ToDateTime(row["start_date"]).ToString("dd MMM yyyy"),
                                     CalculatedEndDate = string.IsNullOrEmpty(row["calc_enddate"].ToString()) ? "" : Convert.ToDateTime(row["calc_enddate"]).ToString("dd MMM yyyy"),
                                     LeaseId = Convert.ToInt32(row["lease_id"]),
                                     Active = Convert.ToInt32(row["active"]),
                                     Status = row["stat"].ToString()
                                 }).ToList();

            return resultRecords.FirstOrDefault();
        }
    }
}
