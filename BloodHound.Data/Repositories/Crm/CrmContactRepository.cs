using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BloodHound.Data.Entities.Crm.Detail;
using BloodHound.Data.Entities.Crm.Table;
using BloodHound.Data.Entities.Mxp.Detail;
using BloodHound.Data.Entities.Mxp.Table;
using BloodHound.Data.Interfaces;
using BloodHound.Data.Interfaces.Repositories;

namespace BloodHound.Data.Repositories.Crm
{
    public class CrmContactRepository : ICrmContactRepository
    {
        private readonly ISQLClient _sqlclient;

        public CrmContactRepository(ISQLClient sqlclient)
        {
            _sqlclient = sqlclient;
        }

        async public Task<IEnumerable<CrmContactTableEntity>> GetTableEntitiesAsync(string accountNumber)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@accountid", SqlDbType = SqlDbType.VarChar, Value = accountNumber }
            };

            var data = await _sqlclient.ExecuteReaderSpAsync("sharepoint.GetCRMContactSummary", parameters.ToArray());

            var resultRecords = (from DataRow row in data.Rows
                                 select new CrmContactTableEntity
                                 {
                                     FirstName = row["firstname"].ToString(),
                                     LastName = row["lastname"].ToString(),
                                     JobTitle = row["jobtitle"].ToString(),
                                     EmailAddress = row["emailaddress1"].ToString(),
                                     ParentAccountName = row["parentcustomeridname"].ToString(),
                                     BusinessPhone = row["telephone1"].ToString(),
                                     ParentCustomerId = row["parentcustomerid"].ToString(),
                                     ContactId = row["contactid"].ToString(),
                                     Mobile = row["mobilephone"].ToString()
                                 }).ToList();

            return resultRecords;
        }
    }
}
