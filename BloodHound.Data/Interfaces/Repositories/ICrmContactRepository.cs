using System.Collections.Generic;
using System.Threading.Tasks;
using BloodHound.Data.Entities.Crm.Detail;
using BloodHound.Data.Entities.Crm.Table;

namespace BloodHound.Data.Interfaces.Repositories
{
    public interface ICrmContactRepository
    {
        Task<IEnumerable<CrmContactTableEntity>> GetTableEntitiesAsync(string accountNumber);
    }
}