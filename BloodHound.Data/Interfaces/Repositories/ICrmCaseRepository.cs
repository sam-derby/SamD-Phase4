using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BloodHound.Data.Entities.Crm.Detail;
using BloodHound.Data.Entities.Crm.Table;

namespace BloodHound.Data.Interfaces.Repositories
{
    public interface ICrmCaseRepository
    {
        Task<IEnumerable<CrmCaseTableEntity>> GetTableEntitiesAsync(int state, Guid accountNumber, DateTime startDate);
        Task<CrmCaseDetailEntity> GetCrmAccountDetailAsync(string ticketNumber, int? state = null, Guid? accountNumber = null, DateTime? startDate = null);
    }
}