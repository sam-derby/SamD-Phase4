using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BloodHound.Data.Entities.Crm.Detail;
using BloodHound.Data.Entities.Crm.Table;

namespace BloodHound.Data.Interfaces.Repositories
{
    public interface ICrmOpportunityRepository
    {
        Task<IEnumerable<CrmOpportunityTableEntity>> GetTableEntitiesAsync(string state = "", DateTime? startDate = null,
            DateTime? endDate = null, string oppNumber = "", Guid? accountId = null);

        Task<CrmOpportunityDetailEntity> GetDetailEntityAsync(string oppNumber);
    }
}