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
    public class MxpCustomerRepository : IMxpCustomerRepository
    {
        private readonly ISQLClient _sqlclient;

        public MxpCustomerRepository(ISQLClient sqlclient)
        {
            _sqlclient = sqlclient;
        }

        async public Task<IEnumerable<MxpCustomerTableEntity>> GetTableEntitiesAsync(string custName, string custNumber)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@Cust_no", SqlDbType = SqlDbType.VarChar, Value = string.Format("%{0}%",custNumber)},
                new SqlParameter {ParameterName = "@Cust_name",SqlDbType = SqlDbType.NVarChar,Value = string.Format("%{0}%",custName)}
            };

            var data = await _sqlclient.ExecuteReaderSpAsync("sharepoint.GetCustomerSummary", parameters.ToArray());

            var resultRecords = (from DataRow row in data.Rows
                                 select new MxpCustomerTableEntity
                                 {
                                     CustomerName = row["name"].ToString(),
                                     CustomerNumber = row["cust_no"].ToString(),
                                     City = row["city"].ToString(),
                                     PostCode = row["zip_code"].ToString(),
                                     Charge = row["chrg"].ToString(),
                                     ChargeCustomerNumber = row["charge_cust"].ToString(),
                                     MachineCount = Convert.ToInt32(row["MCs"].ToString())
                                 }).ToList();

            return resultRecords;
        }

        async public Task<MxpCustomerDetailEntity> GetCustomerDetailAsync(string custNumber)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@Cust_no", SqlDbType = SqlDbType.VarChar, Value = custNumber}
            };

            var data = await _sqlclient.ExecuteReaderSpAsync("sharepoint.GetCustomerDetails", parameters.ToArray());

            var resultRecords = (from DataRow row in data.Rows
                                 select new MxpCustomerDetailEntity
                                 {
                                     CustomerName = row["name"].ToString(),
                                     CustomerNumber = row["cust_no"].ToString(),
                                     City = row["city"].ToString(),
                                     PostCode = row["zip_code"].ToString(),
                                     Charge = row["chrg"].ToString(),
                                     ChargeCustomerNumber = row["charge_cust"].ToString(),
                                     LegalName = row["legal_name"].ToString(),
                                     TradingAs = row["trading_as"].ToString(),
                                     Address1 = row["address##1"].ToString(),
                                     Address2 = row["address##2"].ToString(),
                                     Address3 = row["address##3"].ToString(),
                                     Address4 = row["address##4"].ToString(),
                                     CountryCode = row["country_code"].ToString(),
                                     CurrencyCode = row["currency_cod"].ToString(),
                                     VatReg = row["vat_reg"].ToString(),
                                     CompanyReg = row["co_reg"].ToString(),
                                     ExtprSendMethod = row["extpr_sendmethod"].ToString(),
                                     Sector = row["type_code"].ToString(),
                                     MachineCount = Convert.ToInt32(row["mcs"].ToString())
                                 }).ToList();

            return resultRecords.FirstOrDefault();
        }
    }
}
