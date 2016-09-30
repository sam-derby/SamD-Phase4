using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BloodHound.Data.Entities.Mxp.Detail;
using BloodHound.Data.Entities.Mxp.Table;
using BloodHound.Data.Interfaces;
using BloodHound.Data.Interfaces.Repositories;

namespace BloodHound.Data.Repositories.Mxp
{
    public class MxpServiceCallRepository : IMxpServiceCallRepository
    {
        readonly ISQLClient _sqlclient;
        public MxpServiceCallRepository(ISQLClient sqlclient)
        {
            _sqlclient = sqlclient;
        }

        async public Task<IEnumerable<MxpServiceCallTableEntity>> GetTableEntitiesAsync(string custNumber, DateTime startDate, DateTime endDate, string serviceNumber, string state = "")
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@Service_no", SqlDbType = SqlDbType.VarChar, Value = string.Format("%{0}%",serviceNumber) },
                new SqlParameter {ParameterName = "@Cust_no", SqlDbType = SqlDbType.VarChar, Value = custNumber == string.Empty ? null : custNumber },
                new SqlParameter {ParameterName = "@start_date", SqlDbType = SqlDbType.DateTime, Value = startDate },
                 new SqlParameter {ParameterName = "@end_date", SqlDbType = SqlDbType.DateTime, Value = endDate },
                new SqlParameter {ParameterName = "@state", SqlDbType = SqlDbType.VarChar, Value = state == string.Empty ? null : state },
            };

            var data = await _sqlclient.ExecuteReaderSpAsync("sharepoint.GetServiceSummary", parameters.ToArray());

            var resultRecords = (from DataRow row in data.Rows
                                 select new MxpServiceCallTableEntity
                                 {
                                     ServiceNumber = row["service_no"].ToString(),
                                     EntryDate = string.IsNullOrEmpty(row["entry_date"].ToString()) ? "" : Convert.ToDateTime(row["entry_date"]).ToString("dd MMM yyyy"),
                                     EntryTime = row["entry_time"].ToString(),
                                     SoStatus = row["so_status"].ToString(),
                                     SoStatusDescription = row["so_status_desc"].ToString(),
                                     SerialNumber = row["serial_no"].ToString(),
                                     ItemNumber = row["item_no"].ToString(),
                                     TechCode = row["tech_code"].ToString(),
                                     TechName = row["tech_name"].ToString(),
                                     CustomerNumber = row["cust_no"].ToString(),
                                     ChargeCustomerNumber = row["charge_cust"].ToString(),
                                     ContractNumber = row["contract_no"].ToString(),
                                     ContractLine = Convert.ToInt32(row["contract_lin"]),
                                     ServiceType = row["service_type"].ToString()
                                 }).ToList();

            return resultRecords.OrderBy(m => m.EntryDate).ToList();
        }

        async public Task<IEnumerable<MxpServiceCallTableEntity>> GetTableEntitiesAsync(string custNumber = "",string serviceNumber = "")
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@Service_no", SqlDbType = SqlDbType.VarChar, Value = string.Format("%{0}%",serviceNumber) },
                new SqlParameter {ParameterName = "@Cust_no", SqlDbType = SqlDbType.VarChar, Value = custNumber == string.Empty ? null : custNumber }
            };

            var data = await _sqlclient.ExecuteReaderSpAsync("sharepoint.GetServiceSummary", parameters.ToArray());

            var resultRecords = (from DataRow row in data.Rows
                                 select new MxpServiceCallTableEntity
                                 {
                                     ServiceNumber = row["service_no"].ToString(),
                                     EntryDate = string.IsNullOrEmpty(row["entry_date"].ToString()) ? "" : Convert.ToDateTime(row["entry_date"]).ToString("dd MMM yyyy"),
                                     EntryTime = row["entry_time"].ToString(),
                                     SoStatus = row["so_status"].ToString(),
                                     SoStatusDescription = row["so_status_desc"].ToString(),
                                     SerialNumber = row["serial_no"].ToString(),
                                     ItemNumber = row["item_no"].ToString(),
                                     TechCode = row["tech_code"].ToString(),
                                     TechName = row["tech_name"].ToString(),
                                     CustomerNumber = row["cust_no"].ToString(),
                                     ChargeCustomerNumber = row["charge_cust"].ToString(),
                                     ContractNumber = row["contract_no"].ToString(),
                                     ContractLine = Convert.ToInt32(row["contract_lin"]),
                                     ServiceType = row["service_type"].ToString()
                                 }).ToList();

            return resultRecords.OrderBy(m => m.EntryDate).ToList();
        }

        async public Task<MxpServiceCallDetailEntity> GetDetailEntityAsync(string serviceNumber = "", string custNumber = "", DateTime? startDate = null, DateTime? endDate = null, string state = "")
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@Cust_no", SqlDbType = SqlDbType.VarChar, Value = string.Format("%{0}%",custNumber) },
                new SqlParameter {ParameterName = "@Service_no", SqlDbType = SqlDbType.VarChar, Value = serviceNumber == string.Empty ? Convert.DBNull : serviceNumber },
                new SqlParameter {ParameterName = "@start_date", SqlDbType = SqlDbType.DateTime, Value = startDate ?? Convert.DBNull },
                new SqlParameter {ParameterName = "@end_date", SqlDbType = SqlDbType.DateTime, Value = endDate ?? Convert.DBNull },
                new SqlParameter {ParameterName = "@state", SqlDbType = SqlDbType.VarChar, Value = state == string.Empty ? Convert.DBNull : state }
            };
            try
            {
                var data = await _sqlclient.ExecuteReaderSpAsync("sharepoint.GetServiceDetail", parameters.ToArray());

                var resultRecords = (from DataRow row in data.Rows
                    select new MxpServiceCallDetailEntity
                    {
                        ServiceNumber = row["service_no"].ToString(),
                        EntryDate =
                            string.IsNullOrEmpty(row["entry_date"].ToString())
                                ? ""
                                : Convert.ToDateTime(row["entry_date"]).ToString("dd MMM yyyy"),
                        EntryTime = row["entry_time"].ToString(),
                        SoStatus = row["so_status"].ToString(),
                        SoStatusDescription = row["so_status_desc"].ToString(),
                        SerialNumber = row["serial_no"].ToString(),
                        SystemRef = row["serial_no"].ToString(),
                        ItemNumber = row["item_no"].ToString(),
                        TechCode = row["tech_code"].ToString(),
                        TechName = row["tech_name"].ToString(),
                        ServiceType = row["service_type"].ToString(),
                        CategoryCode = Convert.ToInt32(row["categ_code"]),
                        CategoryCodeDescription = row["categ_code_desc"].ToString(),
                        ProblemCode = row["problem_code"].ToString(),
                        ProblemCodeDescription = row["problem_code_desc"].ToString(),
                        CauseCode = row["cause_code"].ToString(),
                        CauseCodeDescription = row["cause_code_desc"].ToString(),
                        CustomerNumber = row["cust_no"].ToString(),
                        ChargeCustomerNumber = row["charge_cust"].ToString(),
                        ContractNumber = row["contract_no"].ToString(),
                        ContractLine = Convert.ToInt32(row["contract_lin"]),
                        RepairCode = row["repair_code"].ToString(),
                        RepairCodeDescription = row["repair_code_desc"].ToString(),
                        RepairRequestDate =
                            string.IsNullOrEmpty(row["request_date"].ToString())
                                ? ""
                                : Convert.ToDateTime(row["request_date"]).ToString("dd MMM yyyy"),
                        RepairRequestTime = row["request_time"].ToString(),
                        RepairDispatchDate =
                            string.IsNullOrEmpty(row["dispatch_dt"].ToString())
                                ? ""
                                : Convert.ToDateTime(row["dispatch_dt"]).ToString("dd MMM yyyy"),
                        RepairDispatchTime = row["dispatch_tm"].ToString(),
                        RepairArrivalDate =
                            string.IsNullOrEmpty(row["arrive_date"].ToString())
                                ? ""
                                : Convert.ToDateTime(row["arrive_date"]).ToString("dd MMM yyyy"),
                        RepairArrivalTime = row["arrive_time"].ToString(),
                        RepairCompleteDate =
                            string.IsNullOrEmpty(row["complete_dt"].ToString())
                                ? ""
                                : Convert.ToDateTime(row["complete_dt"]).ToString("dd MMM yyyy"),
                        RepairCompleteTime = row["complete_tm"].ToString()
                    }).ToList();

                return resultRecords.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
