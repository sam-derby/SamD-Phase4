using System;
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
    public class CrmAccountRepository : ICrmAccountRepository
    {
        readonly ISQLClient _sqlclient;

        public CrmAccountRepository(ISQLClient sqlclient)
        {
            _sqlclient = sqlclient;
        }

        async public Task<IEnumerable<CrmAccountTableEntity>> GetTableEntitiesAsync(string accountName = "", string mxpCustomerNumber = "")
        {
            if (string.IsNullOrEmpty(accountName) && string.IsNullOrEmpty(mxpCustomerNumber))
                return Enumerable.Empty<CrmAccountTableEntity>();

            SqlParameter parameter = null;
            
            if (!string.IsNullOrEmpty(accountName))
            {
                parameter = new SqlParameter
                {
                    ParameterName = "@name",
                    SqlDbType = SqlDbType.VarChar,
                    Value = string.Format("%{0}%", accountName)
                };
            }
            else
            {
                parameter = new SqlParameter
                {
                    ParameterName = "@mxpGrpId",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = string.Format("{0}", mxpCustomerNumber)
                };
            }
           
            var parameters = new List<SqlParameter>{ parameter };
            var data = await _sqlclient.ExecuteReaderSpAsync("sharepoint.GetCRMAccountSummary", parameters.ToArray());
            var resultRecords = (from DataRow row in data.Rows
                                 select new CrmAccountTableEntity
                                 {
                                     AccountName = row["name"].ToString(),
                                     PostCode = row["address1_postalcode"].ToString(),
                                     City = row["address1_city"].ToString(),
                                     OwnerName = row["owneridname"].ToString(),
                                     ActiveDeviceCount = string.IsNullOrEmpty(row["dw_devicecount"].ToString()) ? "" : row["dw_devicecount"].ToString(),
                                     ParentAccountName = row["parentaccountidname"].ToString(),
                                     LastActivityDate = string.IsNullOrEmpty(row["dw_lastactivitydate"].ToString()) ? "" : Convert.ToDateTime(row["dw_lastactivitydate"]).ToString("dd MMM yyyy"),
                                     NextActivityDate = string.IsNullOrEmpty(row["dw_nextactivitydate"].ToString()) ? "" : Convert.ToDateTime(row["dw_nextactivitydate"]).ToString("dd MMM yyyy"),
                                     AccountNumber = row["accountid"].ToString(),
                                     OwnerId = row["ownerid"].ToString(),
                                     ParentAccountId = row["parentaccountid"].ToString(),
                                     MxpCustomerNumber = row["img_mxpgrpcustid"].ToString(),
                                     OwnerEmailAddress = row["internalemailaddress"].ToString()
                                 }).ToList();

            return resultRecords;
        }

        async public Task<CrmAccountDetailEntity> GetCrmAccountDetailAsync(string accountNumber)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@accountid", SqlDbType = SqlDbType.VarChar, Value = accountNumber}
            };

            var data = await _sqlclient.ExecuteReaderSpAsync("sharepoint.GetCRMAccountDetails", parameters.ToArray());

            var resultRecords = (from DataRow row in data.Rows
                                 select new CrmAccountDetailEntity
                                 {
                                     AccountName = row["name"].ToString(),
                                     PostCode = row["address1_postalcode"].ToString(),
                                     City = row["address1_city"].ToString(),
                                     OwnerName = row["owneridname"].ToString(),
                                     ActiveDeviceCount = string.IsNullOrEmpty(row["dw_devicecount"].ToString()) ? "" : row["dw_devicecount"].ToString(),
                                     AccountNumber = row["accountid"].ToString(),
                                     OwnerId = row["ownerid"].ToString(),
                                     ParentAccountId = row["parentaccountid"].ToString(),
                                     PatchId = row["img_patchidname"].ToString(),
                                     CustomerSector = row["accountcategorycodename"].ToString(),
                                     Category = row["img_vmscategoryname"].ToString(),
                                     SubCategory = row["img_vmssubcategoryname"].ToString(),
                                     PrimarySalesContact = row["primarycontactidname"].ToString(),
                                     PrimaryServiceContact = row["img_primarygeneralcontact"].ToString(),
                                     Email = row["emailaddress1"].ToString(),
                                     BusinessPhone = row["address1_telephone1"].ToString(),
                                     Street1 = row["address1_line1"].ToString(),
                                     Street2 = row["address1_line2"].ToString(),
                                     Street3 = row["address1_line3"].ToString(),
                                     CountryRegion = row["address1_stateorprovince"].ToString(),
                                     Country = row["address1_country"].ToString(),
                                     PrimaryContactId = row["primarycontactid"].ToString(),
                                     PrimaryGeneralContactId = row["img_primarygeneralcontact1"].ToString(),
                                     MxpCustomerNumber = row["img_mxpgrpcustid"].ToString(),
                                     CrmSharepointId = row["outs_sharepointid"].ToString(),
                                     ParentAccountName = row["parentaccountidname"].ToString(),
                                     OwnerEmailAddress = row["internalemailaddress"].ToString()
                                 }).ToList();

            return resultRecords.FirstOrDefault();
        }
    }
}
