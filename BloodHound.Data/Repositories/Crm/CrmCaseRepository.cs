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
    public class CrmCaseRepository : ICrmCaseRepository
    {
        readonly ISQLClient _sqlclient;

        public CrmCaseRepository(ISQLClient sqlclient)
        {
            _sqlclient = sqlclient;
        }

        async public Task<IEnumerable<CrmCaseTableEntity>> GetTableEntitiesAsync(int state, Guid accountNumber, DateTime startDate)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@state", SqlDbType = SqlDbType.Int, Value = state },
                new SqlParameter {ParameterName = "@accountID", SqlDbType = SqlDbType.UniqueIdentifier, Value = accountNumber },
                new SqlParameter {ParameterName = "@start_data", SqlDbType = SqlDbType.DateTime, Value = startDate }
            };

            var data = await _sqlclient.ExecuteReaderSpAsync("sharepoint.GetCRMCaseSummary", parameters.ToArray());

            var resultRecords = (from DataRow row in data.Rows
                                 select new CrmCaseTableEntity
                                 {
                                     Title = row["title"].ToString(),
                                     CaseTypeCode = Convert.ToInt32(row["casetypecode"]),
                                     CaseTypeCodeName = row["casetypecodename"].ToString(),
                                     TicketNumber = row["ticketnumber"].ToString(),
                                     PriorityCode = Convert.ToInt32(row["prioritycode"]),
                                     PriorityCodeName = row["prioritycodename"].ToString(),
                                     CreatedOn = string.IsNullOrEmpty(row["createdon"].ToString()) ? "" : Convert.ToDateTime(row["createdon"]).ToString("dd MMM yyyy"),
                                     CustomerId = row["customerid"].ToString(),
                                     CustomerIdName = row["customeridname"].ToString(),
                                     StateCode = Convert.ToInt32(row["statecode"]),
                                     StateCodeName = row["statecodename"].ToString(),
                                     StatusCode = Convert.ToInt32(row["statuscode"]),
                                     StatusCodeName = row["statuscodename"].ToString(),
                                 }).ToList();

            return resultRecords;
        }

        async public Task<CrmCaseDetailEntity> GetCrmAccountDetailAsync(string ticketNumber, int? state = null, Guid? accountNumber = null, DateTime? startDate = null)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@state", SqlDbType = SqlDbType.Int, Value = state },
                new SqlParameter {ParameterName = "@accountID", SqlDbType = SqlDbType.UniqueIdentifier, Value = accountNumber },
                new SqlParameter {ParameterName = "@start_data", SqlDbType = SqlDbType.DateTime, Value = startDate },
                new SqlParameter {ParameterName = "@ticket", SqlDbType = SqlDbType.NVarChar, Value = ticketNumber },
            };

            var data = await _sqlclient.ExecuteReaderSpAsync("sharepoint.GetCRMCaseDetail", parameters.ToArray());

            var resultRecords = (from DataRow row in data.Rows
                                 select new CrmCaseDetailEntity
                                 {
                                     Title = row["title"].ToString(),
                                     CaseTypeCode = Convert.ToInt32(row["casetypecodename"]),
                                     TicketNumber = row["ticketnumber"].ToString(),
                                     PriorityCode = Convert.ToInt32(row["prioritycode"]),
                                     PriorityCodeName = row["prioritycodename"].ToString(),
                                     CreatedOn = string.IsNullOrEmpty(row["createdon"].ToString()) ? "" : Convert.ToDateTime(row["createdon"]).ToString("dd MMM yyyy"),
                                     CustomerId = row["customerid"].ToString(),
                                     CustomerIdName = row["customeridname"].ToString(),
                                     StateCode = Convert.ToInt32(row["statecode"]),
                                     StateCodeName = row["statecodename"].ToString(),
                                     StatusCode = Convert.ToInt32(row["statuscode"]),
                                     StatusCodeName = row["statuscodename"].ToString(),
                                     OwneridName = row["owneridname"].ToString(),
                                     CaseCategoryIdName = row["img_casecategoryidname"].ToString(),
                                     CaseSubCategoryIdName = row["img_casesubcategoryidname"].ToString(),
                                     CaseSubCategoryDetailIdName = row["img_casesubcategorydetailidname"].ToString(),
                                     FollowUpBy = string.IsNullOrEmpty(row["followupby"].ToString()) ? "" : Convert.ToDateTime(row["followupby"]).ToString("dd MMM yyyy"),
                                     Description = row["description"].ToString(),
                                     CaseType = row["casetypecodename"].ToString(),
                                     OwnerId = row["ownerid"].ToString(),
                                     InternalEmailAddress = row["internalemailAddress"].ToString(),
                                     CaseCategoryId = row["img_casecategoryid"].ToString(),
                                     CaseSubCategoryId = row["img_casesubcategoryid"].ToString(),
                                     CaseSubCategoryDetailId = row["img_casesubcategorydetailid"].ToString(),
                                     ResponsibleContact = row["img_responsiblecontact"].ToString()

                                 }).ToList();

            return resultRecords.FirstOrDefault();
        }
    }
}
