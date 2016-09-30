using System.Collections.Generic;
using System.Threading.Tasks;
using BloodHound.Data.Entities.Mxp.Detail;
using BloodHound.Data.Entities.Mxp.Table;

namespace BloodHound.Data.Interfaces.Repositories
{
    public interface IMxpLeaseRepository
    {
        Task<IEnumerable<MxpLeaseTableEntity>> GetTableEntitiesAsync(string custNumber);
        Task<MxpLeaseDetailEntity> GetDetailEntitieAsync(int leaseId);
        Task<IEnumerable<MxpLeaseTableEntity>> SearchTableEntitiesAsync(string leaseRef);
    }
}