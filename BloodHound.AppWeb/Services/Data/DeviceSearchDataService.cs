using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BloodHound.AppWeb.Interfaces.Services.Data;
using BloodHound.AppWeb.Models;
using BloodHound.Core.Logging;
using BloodHound.Data.Interfaces.Repositories;

namespace BloodHound.AppWeb.Services.Data
{
    public class DeviceSearchDataService : DataService, IDeviceSearchDataService
    {
        private readonly IMxpDeviceRepository _mxpDeviceRepository;

        public DeviceSearchDataService(IMxpDeviceRepository mxpDeviceRepository, ILogWriter logWriter) : base(logWriter)
        {
            _mxpDeviceRepository = mxpDeviceRepository;
        }

        async public Task<ResponseModel> SearchByCustomerNumberAsync(string custNumber)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _mxpDeviceRepository.GetTableEntitiesAsync(custNumber: custNumber);
                HasData = data.Any();
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No results found for {0}", custNumber), ResponseCode = HasData ? 200 : 204 };
            });
        }

        async public Task<ResponseModel> SearchBySystemRefAsync(string sysRef)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _mxpDeviceRepository.GetTableEntitiesAsync(sysRef: sysRef);
                HasData = data.Any();
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No results found for {0}", sysRef), ResponseCode = HasData ? 200 : 204 };
            });
        }

        async public Task<ResponseModel> SearchBySerialNumberAsync(string serialNumber)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _mxpDeviceRepository.GetTableEntitiesAsync(serialNumber: serialNumber);
                HasData = data.Any();
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No results found for {0}", serialNumber), ResponseCode = HasData ? 200 : 204 };
            });
        }

        async public Task<ResponseModel> SearchByAlternativeReferenceAsync(string altRef)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _mxpDeviceRepository.GetTableEntitiesAsync(altRef: altRef);
                HasData = data.Any();
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No results found for {0}", altRef), ResponseCode = HasData ? 200 : 204 };
            });
        }


        async public Task<ResponseModel> SearchByLeaseIdAsync(int leaseId)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _mxpDeviceRepository.GetTableEntitiesAsync(leaseId: leaseId);
                HasData = data.Any();
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No results found for {0}", leaseId), ResponseCode = HasData ? 200 : 204 };
            });
        }
    }
}