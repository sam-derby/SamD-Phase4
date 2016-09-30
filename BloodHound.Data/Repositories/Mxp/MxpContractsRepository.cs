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
    public class MxpContractsRepository : IMxpContractsRepository
    {
        readonly ISQLClient _sqlClient;

        public MxpContractsRepository(ISQLClient sqlClient)
        {
            _sqlClient = sqlClient;
        }

        async public Task<IEnumerable<MxpContractHeaderTableEntity>> GetContractHeaderTableEntitiesAsync(string custNumber)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@cust_no", SqlDbType = SqlDbType.VarChar, Value = custNumber }
            };
            var data = await _sqlClient.ExecuteReaderSpAsync("sharepoint.GetContractHeaderSummary", parameters.ToArray());
            var resultRecords = (from DataRow row in data.Rows
                                 select new MxpContractHeaderTableEntity
                                 {
                                     ContractNumber = row["contract_no"].ToString(),
                                     CustomerNumber = row["Cust_no"].ToString(),
                                     Description = row["description"].ToString(),
                                     NumberOfLines = Convert.ToInt32(row["NoLines"]),
                                     ContractStartDate = string.IsNullOrEmpty(row["cntrct_start"].ToString()) ? "" : Convert.ToDateTime(row["cntrct_start"]).ToString("dd MMM yyyy"),
                                     ContractEndDate = string.IsNullOrEmpty(row["cntrct_end"].ToString()) ? "" : Convert.ToDateTime(row["cntrct_end"]).ToString("dd MMM yyyy"),
                                     ChargeCustomerNumber = row["charge_cust"].ToString(),
                                     BillCycle = Convert.ToInt32(row["bill_cycle"])
                                 }).ToList();
            return resultRecords;
        }

        async public Task<IEnumerable<MxpContractHeaderTableEntity>> SearchContractHeaderTableEntitiesAsync(string contractNumber)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@contract_no", SqlDbType = SqlDbType.VarChar, Value = string.Format("%{0}%",contractNumber) }
            };
            var data = await _sqlClient.ExecuteReaderSpAsync("sharepoint.GetContractHeaderSummary", parameters.ToArray());
            var resultRecords = (from DataRow row in data.Rows
                                 select new MxpContractHeaderTableEntity
                                 {
                                     ContractNumber = row["contract_no"].ToString(),
                                     CustomerNumber = row["Cust_no"].ToString(),
                                     Description = row["description"].ToString(),
                                     NumberOfLines = Convert.ToInt32(row["NoLines"]),
                                     ContractStartDate = string.IsNullOrEmpty(row["cntrct_start"].ToString()) ? "" : Convert.ToDateTime(row["cntrct_start"]).ToString("dd MMM yyyy"),
                                     ContractEndDate = string.IsNullOrEmpty(row["cntrct_end"].ToString()) ? "" : Convert.ToDateTime(row["cntrct_end"]).ToString("dd MMM yyyy"),
                                     ChargeCustomerNumber = row["charge_cust"].ToString(),
                                     BillCycle = Convert.ToInt32(row["bill_cycle"])
                                 }).ToList();
            return resultRecords;
        }

        async public Task<IEnumerable<MxpContractLinesTableEntity>> GetContractLinesTableEntitiesAsync(string contractNumber , string customerNumber)
        {
            var parameters = new List<SqlParameter>
            {
                 new SqlParameter {ParameterName = "@Contract_no ", SqlDbType = SqlDbType.VarChar, Value = contractNumber },
                 new SqlParameter {ParameterName = "@cust_no ", SqlDbType = SqlDbType.VarChar, Value = customerNumber }
            };
            var data = await _sqlClient.ExecuteReaderSpAsync("sharepoint.GetContractLineSummary", parameters.ToArray());
            var resultRecords = (from DataRow row in data.Rows
                                 select new MxpContractLinesTableEntity
                                 {
                                     ContractNumber = row["contract_no"].ToString(),
                                     CustomerNumber = row["Cust_no"].ToString(),
                                     Description = row["description"].ToString(),
                                     ItemNumber = row["item_no"].ToString(),
                                     LineNumber = row["line_no"].ToString(),
                                     ItemDescription = row["itemDescription"].ToString(),
                                     SerialNumber = row["serial_no"].ToString(),
                                     ChargeCustomerNumber = row["charge_cust"].ToString()
                                 }).ToList();
            return resultRecords;
        }

        async public Task<MxpContractLinesDetailEntity> GetContractLineDetailEntityAsync(string custNumber , string contractNumber , string lineNumber)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@cust_no", SqlDbType = SqlDbType.VarChar, Value = custNumber },
                new SqlParameter {ParameterName = "@Contract_no", SqlDbType = SqlDbType.VarChar, Value = contractNumber },
                new SqlParameter {ParameterName = "@Line_no", SqlDbType = SqlDbType.VarChar, Value = lineNumber }
            };
            var data = await _sqlClient.ExecuteReaderSpAsync("sharepoint.GetContractLineDetails", parameters.ToArray());
            var resultRecords = (from DataRow row in data.Rows
                                 select new MxpContractLinesDetailEntity
                                 {
                                     ContractNumber = row["contract_no"].ToString(),
                                     CustomerNumber = row["cust_no"].ToString(),
                                     Description = row["description"].ToString(),
                                     ItemDescription = row["itemDescription"].ToString(),
                                     ItemNumber = row["item_no"].ToString(),
                                     LineNumber = row["line_no"].ToString(),
                                     SerialNumber = row["serial_no"].ToString(),
                                     ContractStartDate = string.IsNullOrEmpty(row["cntrct_start"].ToString()) ? "" : Convert.ToDateTime(row["cntrct_start"]).ToString("dd MMM yyyy"),
                                     ContractEndDate = string.IsNullOrEmpty(row["cntrct_end"].ToString()) ? "" : Convert.ToDateTime(row["cntrct_end"]).ToString("dd MMM yyyy"),
                                     PartInclusiveEnd = string.IsNullOrEmpty(row["pi_end_dt"].ToString()) ? "" : Convert.ToDateTime(row["pi_end_dt"]).ToString("dd MMM yyyy"),
                                     NextPriceIncreaseDate = string.IsNullOrEmpty(row["next_pri_dt"].ToString()) ? "" : Convert.ToDateTime(row["next_pri_dt"]).ToString("dd MMM yyyy"),
                                     ChargeCustomerNumber = row["charge_cust"].ToString(),
                                     MaxIncrease = row["max_incr__"].ToString(),
                                     LeaseRef = row["lease_ref"].ToString(),
                                     SystemRef = row["acqsystemref"].ToString()
                                 }).ToList();
            return resultRecords.FirstOrDefault();
        }

        async public Task<IEnumerable<MxpContractLineCategoryTableEntity>> GetContractLineCategoryTableEntitiesAsync(string contractNumber, decimal lineNumber)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@contract_no", SqlDbType = SqlDbType.VarChar, Value = contractNumber },
                new SqlParameter {ParameterName = "@line_no", SqlDbType = SqlDbType.Decimal, Value = lineNumber }
            };
            try
            {
                var data =
                    await _sqlClient.ExecuteReaderSpAsync("sharepoint.GetContractLineCateg", parameters.ToArray());
                var resultRecords = (from DataRow row in data.Rows
                    select new MxpContractLineCategoryTableEntity
                    {
                        ProdGroup = row["prod_group"].ToString(),
                        Description = row["description"].ToString(),
                        Flag = row["flag"].ToString().ToLower() == "yes"
                    }).ToList();
                return resultRecords;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
