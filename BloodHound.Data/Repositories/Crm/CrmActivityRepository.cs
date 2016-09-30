using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BloodHound.Data.Entities.Crm.Table;
using BloodHound.Data.Interfaces;
using BloodHound.Data.Interfaces.Repositories;

namespace BloodHound.Data.Repositories.Crm
{
    public class CrmActivityRepository : ICrmActivityRepository
    {
        private readonly ISQLClient _sqlclient;

        public CrmActivityRepository(ISQLClient sqlclient)
        {
            _sqlclient = sqlclient;
        }

        async public Task<IEnumerable<CrmActivityTableEntity>> GetTableEntitiesAsync(int state, Guid accountNumber, DateTime startDate, int regardingTypeCode)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@state", SqlDbType = SqlDbType.Int, Value = state },
                new SqlParameter {ParameterName = "@accountid", SqlDbType = SqlDbType.UniqueIdentifier, Value = accountNumber },
                new SqlParameter {ParameterName = "@start_date", SqlDbType = SqlDbType.DateTime, Value = startDate },
                new SqlParameter {ParameterName = "@regardingTypeCode", SqlDbType = SqlDbType.Int, Value = regardingTypeCode }
            };

            var data = await _sqlclient.ExecuteReaderSpAsync("sharepoint.GetCRMActivitySummary", parameters.ToArray());

            var resultRecords = (from DataRow row in data.Rows
                                 select new CrmActivityTableEntity
                                 {
                                     ActivityType = row["activitytypecodename"].ToString(),
                                     Subject = row["subject"].ToString(),
                                     RegardingObjectIdName = row["regardingobjectidname"].ToString(),
                                     RegardingObjectTypeCode = row["regardingobjecttypecode"].ToString(),
                                     PriorityCodeName = row["prioritycodename"].ToString(),
                                     ScheduledStartDate = string.IsNullOrEmpty(row["scheduledstart"].ToString()) ? "" : Convert.ToDateTime(row["scheduledstart"]).ToString("dd MMM yyyy"),
                                     ScheduledEndDate = string.IsNullOrEmpty(row["scheduledend"].ToString()) ? "" : Convert.ToDateTime(row["scheduledend"]).ToString("dd MMM yyyy"),
                                     OwnerIdName = row["owneridname"].ToString(),
                                     InternalEmailAddress = row["internalemailaddress"].ToString(),
                                     ActualStartDate = string.IsNullOrEmpty(row["actualstart"].ToString()) ? "" : Convert.ToDateTime(row["actualstart"]).ToString("dd MMM yyyy"),
                                     ActualEndDate = string.IsNullOrEmpty(row["actualend"].ToString()) ? "" : Convert.ToDateTime(row["actualend"]).ToString("dd MMM yyyy"),
                                     PriorityCode = Convert.ToInt32(row["prioritycode"].ToString()),
                                     OwnerId = row["ownerid"].ToString(),
                                     RegardingObjectid = row["regardingobjectid"].ToString(),
                                     StateCode = Convert.ToInt32(row["statecode"].ToString()),
                                     StateCodeName = row["statecodename"].ToString(),
                                     StatusCode = Convert.ToInt32(row["statuscode"].ToString()),
                                     StatusCodeName = row["statuscodename"].ToString()
                                 }).ToList();

            return resultRecords;
        }
    }
}
