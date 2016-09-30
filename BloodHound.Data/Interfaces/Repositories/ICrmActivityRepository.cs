using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BloodHound.Data.Entities.Crm.Table;

namespace BloodHound.Data.Interfaces.Repositories
{
    public interface ICrmActivityRepository
    {
        Task<IEnumerable<CrmActivityTableEntity>> GetTableEntitiesAsync(int state, Guid accountNumber,
            DateTime startDate, int regardingTypeCode);
    }
}