using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BloodHound.Data.Entities.Mxp.Detail;
using BloodHound.Data.Entities.Mxp.Table;

namespace BloodHound.Data.Interfaces.Repositories
{
    public interface IMxpServiceCallRepository
    {
        Task<IEnumerable<MxpServiceCallTableEntity>> GetTableEntitiesAsync(string custNumber, DateTime startDate,
            DateTime endDate, string state = "", string serviceNumber = "");

        Task<MxpServiceCallDetailEntity> GetDetailEntityAsync(string serviceNumber = "",
            string custNumber = "", DateTime? startDate = null, DateTime? endDate = null, string state = "");

        Task<IEnumerable<MxpServiceCallTableEntity>> GetTableEntitiesAsync(string custNumber = "",
            string serviceNumber = "");
    }
}