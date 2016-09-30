using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodHound.Data.Entities.Crm.Detail;
using BloodHound.Data.Entities.Crm.Table;
using BloodHound.Data.Entities.Mxp.Table;
using BloodHound.Data.Interfaces;
using BloodHound.Data.Interfaces.Repositories;

namespace BloodHound.Data.Repositories.Crm
{
    public class CrmOpportunityRepository : ICrmOpportunityRepository
    {
        readonly ISQLClient _sqlclient;
        public CrmOpportunityRepository(ISQLClient sqlclient)
        {
            _sqlclient = sqlclient;
        }

        async public Task<IEnumerable<CrmOpportunityTableEntity>> GetTableEntitiesAsync(string state = "", DateTime? startDate = null, DateTime? endDate = null, string oppNumber = "" , Guid? accountId = null)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@oppno", SqlDbType = SqlDbType.VarChar, Value = string.Format("%{0}%",oppNumber) },
                new SqlParameter {ParameterName = "@accountId", SqlDbType = SqlDbType.UniqueIdentifier, Value = accountId },
                new SqlParameter {ParameterName = "@start_date", SqlDbType = SqlDbType.DateTime, Value = startDate },
                new SqlParameter {ParameterName = "@end_date", SqlDbType = SqlDbType.DateTime, Value = endDate },
                new SqlParameter {ParameterName = "@state", SqlDbType = SqlDbType.VarChar, Value = state == string.Empty ? null : state },
            };

            var data = await _sqlclient.ExecuteReaderSpAsync("sharepoint.GetCRMOpportunitySummary", parameters.ToArray());

            var resultRecords = (from DataRow row in data.Rows
                                 select new CrmOpportunityTableEntity
                                 {
                                     OpportunityNumber = row["dw_oppno"].ToString(),
                                     EstimatedCloseDate = string.IsNullOrEmpty(row["estimatedclosedate"].ToString()) ? "" : Convert.ToDateTime(row["estimatedclosedate"]).ToString("dd MMM yyyy"),
                                     ActualCloseDate = string.IsNullOrEmpty(row["actualclosedate"].ToString()) ? "" : Convert.ToDateTime(row["actualclosedate"]).ToString("dd MMM yyyy"),
                                     Topic = row["name"].ToString(),
                                     PotentialCustomerName = row["customeridname"].ToString(),
                                     StatusCodeName = row["statuscodename"].ToString(),
                                     OwnerIdName = row["owneridname"].ToString(),
                                     OwnerEmailAddress = row["internalemailaddress"].ToString(),
                                     CustomerId = row["customerid"].ToString(),
                                     OpportunityId = row["opportunityid"].ToString(),
                                     OwnerId = row["ownerid"].ToString(),
                                     StateCodeName = row["statecodename"].ToString(),
                                     StatusCode = Convert.ToInt32(row["statecode"])
                                 }).ToList();

            return resultRecords.OrderBy(m => m.ActualCloseDate).ToList();
        }

        async public Task<CrmOpportunityDetailEntity> GetDetailEntityAsync(string oppNumber)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@oppno", SqlDbType = SqlDbType.VarChar, Value = oppNumber },
            };

            var data = await _sqlclient.ExecuteReaderSpAsync("sharepoint.GetCRMOpportunityDetail", parameters.ToArray());

            var resultRecords = (from DataRow row in data.Rows
                                 select new CrmOpportunityDetailEntity
                                 {
                                     OpportunityNumber = row["oppno"].ToString(),
                                     EstimatedCloseDate = string.IsNullOrEmpty(row["estimatedclosedate"].ToString()) ? "" : Convert.ToDateTime(row["estimatedclosedate"]).ToString("dd MMM yyyy"),
                                     ActualCloseDate = string.IsNullOrEmpty(row["actualclosedate"].ToString()) ? "" : Convert.ToDateTime(row["actualclosedate"]).ToString("dd MMM yyyy"),
                                     Topic = row["name"].ToString(),
                                     PotentialCustomerName = row["customeridname"].ToString(),
                                     StatusCodeName = row["statuscodename"].ToString(),
                                     OwnerIdName = row["owneridname"].ToString(),
                                     OwnerEmailAddress = row["internalemailaddress"].ToString(),
                                     CustomerId = row["customerid"].ToString(),
                                     OpportunityId = row["opportunityid"].ToString(),
                                     OwnerId = row["ownerid"].ToString(),
                                     StateCodeName = row["statecodename"].ToString(),
                                     StatusCode = Convert.ToInt32(row["statecode"]),
                                     EstSalesRevenue = row["estimatedvalue_base"].ToString(),
                                     OpportunityTypeName = row["img_opportunitytypename"].ToString(),
                                     ProcurementProcess = row["purchaseprocessname"].ToString(),
                                     EstServiceRevenue = row["img_estservicerevenue_base"].ToString(),
                                     ActualValueBase = row["actualvalue_base"].ToString(),
                                     DwActualBase = row["dw_actualvalue_base"].ToString(),
                                     StateCode = Convert.ToInt32(row["statecode"]),
                                     ImgOpportunityType = Convert.ToInt32(row["img_opportunitytype"]),
                                     PurchaseProcess = Convert.ToInt32(row["purchaseprocess"])
                                 }).ToList();

            return resultRecords.FirstOrDefault();
        }
    }
}
