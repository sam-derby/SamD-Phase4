using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BloodHound.AppWeb.Interfaces.Services;
using BloodHound.AppWeb.Interfaces.Services.Data;
using BloodHound.AppWeb.Models;
using BloodHound.Core.Exceptions;
using BloodHound.Core.Logging;
using BloodHound.Data.Entities.Crm.Table;
using BloodHound.Data.Enums;
using BloodHound.Data.Interfaces.Repositories;
using Microsoft.SharePoint.Client;

namespace BloodHound.AppWeb.Services.Data
{
    public class CrmDataService : DataService, ICrmDataService
    {
        readonly ICrmAccountRepository _crmAccountRepository;
        readonly ICrmContactRepository _crmContactRepository;
        readonly ICrmDeviceRepository _crmDeviceRepository;
        readonly IMxpDeviceRepository _mxpDeviceRepository;
        readonly ISharepointSearchService _sharepointSearchService;

        public CrmDataService(ICrmAccountRepository crmAccountRepository, ICrmContactRepository crmContactRepository,
            ICrmDeviceRepository crmDeviceRepository, ISharepointSearchService sharepointSearchService,
            ILogWriter logWriter, IMxpDeviceRepository mxpDeviceRepository) : base(logWriter)
        {
            _crmAccountRepository = crmAccountRepository;
            _crmContactRepository = crmContactRepository;
            _crmDeviceRepository = crmDeviceRepository;
            _sharepointSearchService = sharepointSearchService;
            _mxpDeviceRepository = mxpDeviceRepository;
        }

        async public Task<ResponseModel> SearchByCustomerNameAsync(string accountName)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _crmAccountRepository.GetTableEntitiesAsync(accountName);
                HasData = data.Any();
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No CRM accounts found for {0}", accountName), ResponseCode = HasData ? 200 : 204 };
            });
        }

        async public Task<ResponseModel> GetAccountAsync(string accountNumber)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _crmAccountRepository.GetCrmAccountDetailAsync(accountNumber);
                if (data != null)
                {
                    var sharepointUrl = _sharepointSearchService.GetCrmSiteUrl(data.CrmSharepointId);
                    data.CrmSharepointUrl = sharepointUrl;
                }
                HasData = data != null;
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No CRM account found for {0}", accountNumber), ResponseCode = HasData ? 200 : 404 };
            });
        }

        async public Task<ResponseModel> GetMxpCrmRecordsAsync(string custNumber)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _crmAccountRepository.GetTableEntitiesAsync(mxpCustomerNumber: custNumber);
                HasData = data.Any();
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No CRM accounts found for {0}", custNumber), ResponseCode = HasData ? 200 : 204 };
            });
        }

        async public Task<ResponseModel> GetCrmContactsAsync(string accountNumber)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _crmContactRepository.GetTableEntitiesAsync(accountNumber);
                HasData = data.Any();
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No CRM contacts found for this account"), ResponseCode = HasData ? 200 : 204 };
            });
        }

        async public Task<ResponseModel> GetCrmDevicesByMxpCustomerNumberAsync(string customerNumber)
        {
            return await FecthDataAsync(async () =>
            {
                var crmDevices = new List<CrmDeviceTableEntity>();
                var crmAccounts = await _crmAccountRepository.GetTableEntitiesAsync(mxpCustomerNumber: customerNumber);
                foreach (var account in crmAccounts)
                {
                    crmDevices.AddRange(await _crmDeviceRepository.GetTableEntitiesAsync(new Guid(account.AccountNumber)));
                }
                HasData = crmDevices.Any();
                return new ResponseModel { Data = crmDevices, Message = HasData ? string.Empty : string.Format("No CRM devices found for customer {0}", customerNumber), ResponseCode = HasData ? 200 : 204 };
            });
        }

        async public Task<ResponseModel> GetDevicesByAccountNumberAsync(string accountNumber)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _crmDeviceRepository.GetTableEntitiesAsync(new Guid(accountNumber));
                HasData = data.Any();
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No CRM devices found for this account"), ResponseCode = HasData ? 200 : 204 };
            });
           
        }

        async public Task<ResponseModel> GetDeviceByDeviceIdAsync(string deviceId)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _crmDeviceRepository.GetDeviceDetailAsync(new Guid(deviceId));
                HasData = data != null;
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No CRM device found for device Id {0}", deviceId), ResponseCode = HasData ? 200 : 404 };
            });
        }

        async public Task<ResponseModel> GetDeviceBySysRefAsync(string systemRef)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _crmDeviceRepository.GetDeviceDetailBySysRefAsync(systemRef);
                HasData = data != null;
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No CRM device found for system reference number {0}", systemRef), ResponseCode = HasData ? 200 : 404 };
            });
        }

        async public Task<ResponseModel> GetDeviceAndStatusBySysRefAsync(string systemRef)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _crmDeviceRepository.GetDeviceDetailBySysRefAsync(systemRef);
                if (data != null)
                {
                    var mxpDevice = await _mxpDeviceRepository.GetDeviceDetailAsync(systemRef);
                    if (mxpDevice == null)
                    {
                        data.CrmMxpStatus = CrmMxpStatus.DoesntExistInMxp;
                    }
                    else if (mxpDevice.MxpCustomerNumber != data.CustomerNumber)
                    {
                        data.CrmMxpStatus = CrmMxpStatus.ExistsInMxpNotInCrm;
                    }
                    else
                    {
                        data.CrmMxpStatus = CrmMxpStatus.ExistsCrmAndMxp;
                    }
                }
                HasData = data != null;
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No device found for System Ref {0}", systemRef), ResponseCode = HasData ? 200 : 404 };
            });

        }
    }
}