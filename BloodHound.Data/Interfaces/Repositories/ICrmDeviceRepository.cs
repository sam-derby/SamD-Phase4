using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BloodHound.Data.Entities.Crm.Detail;
using BloodHound.Data.Entities.Crm.Table;

namespace BloodHound.Data.Interfaces.Repositories
{
    public interface ICrmDeviceRepository
    {
        Task<IEnumerable<CrmDeviceTableEntity>> GetTableEntitiesAsync(Guid accountNumber);
        Task<CrmDeviceDetailEntity> GetDeviceDetailAsync(Guid deviceId);
        Task<CrmDeviceDetailEntity> GetDeviceDetailBySysRefAsync(string sysRef);
    }
}