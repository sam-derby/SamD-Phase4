using System.Collections.Generic;
using System.Threading.Tasks;
using BloodHound.Data.Entities.Mxp.Detail;
using BloodHound.Data.Entities.Mxp.Table;

namespace BloodHound.Data.Interfaces.Repositories
{
    public interface IMxpDeviceRepository
    {
        Task<IEnumerable<MxpDeviceTableEntity>> GetTableEntitiesAsync(string custNumber = "", string sysRef = "",
            string serialNumber = "", string altRef = "", int? leaseId = null);
        Task<MxpDeviceDetailEntity> GetDeviceDetailAsync(string systemRef);
    }
}