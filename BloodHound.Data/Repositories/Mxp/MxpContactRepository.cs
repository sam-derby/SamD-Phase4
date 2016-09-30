using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodHound.Core.Logging;
using BloodHound.Data.Entities.Mxp.Detail;
using BloodHound.Data.Entities.Mxp.Table;
using BloodHound.Data.Interfaces;
using BloodHound.Data.Interfaces.Repositories;

namespace BloodHound.Data.Repositories.Mxp
{
    public class MxpContactRepository : IMxpContactRepository
    {
        readonly ISQLClient _sqlclient;

        public MxpContactRepository(ISQLClient sqlclient)
        {
            _sqlclient = sqlclient;
        }
        async public Task<IEnumerable<MxpCustomerContactDetailEntity>> GetDetailEntitiesAsync(string custNumber)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@Cust_no", SqlDbType = SqlDbType.VarChar, Value = custNumber }
            };
           
            var data = await _sqlclient.ExecuteReaderSpAsync("sharepoint.GetContactDetails", parameters.ToArray());

            var resultRecords = (from DataRow row in data.Rows
                select new MxpCustomerContactDetailEntity
                {
                    ChargeCustomer = row["charge_cust"].ToString(),
                    CustomerNumber = row["cust_no"].ToString(),
                    Name = row["contact"].ToString(),
                    Telephone = row["telephone"].ToString(),
                    Mobile = row["mobile"].ToString(),
                    EmailAddress = row["email_add"].ToString(),
                }).ToList();

            return resultRecords;
        }
    }
}
