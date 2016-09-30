using System.Collections.Generic;
using System.Threading.Tasks;
using BloodHound.Data.Entities.Mxp.Detail;
using BloodHound.Data.Entities.Mxp.Table;

namespace BloodHound.Data.Interfaces.Repositories
{
    public interface IMxpCustomerRepository
    {
        //
        Task<IEnumerable<MxpCustomerTableEntity>> GetTableEntitiesAsync(string custName, string custNumber);
        Task<MxpCustomerDetailEntity> GetCustomerDetailAsync(string custNumber);
    }
}
