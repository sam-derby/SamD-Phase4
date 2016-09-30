using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BloodHound.AppWeb.Interfaces.Services;
using BloodHound.AppWeb.Interfaces.Services.Data;
using BloodHound.AppWeb.Models;
using BloodHound.Core.Logging;
using BloodHound.Data.Enums;
using BloodHound.Data.Interfaces.Repositories;

namespace BloodHound.AppWeb.Services.Data
{
    public class MxpDataService : DataService, IMxpDataService
    {
        readonly IMxpCustomerRepository _mxpCustomerRepository;
        readonly IMxpContactRepository _mxpContactRepository;
        readonly IMxpDeviceRepository _mxpDeviceRepository;
        readonly ICrmDeviceRepository _crmDeviceRepository;
        readonly IMxpContractsRepository _mxpContractsRepository;
        readonly IMxpLeaseRepository _mxpLeaseRepository;
        readonly IMxpServiceCallRepository _mxpServiceCallRepository;
        readonly ISharepointListService _sharepointListService;

        public MxpDataService(IMxpCustomerRepository mxpCustomerRepository, IMxpContactRepository mxpContactRepository, 
            IMxpDeviceRepository mxpDeviceRepository, ICrmDeviceRepository crmDeviceRepository, ILogWriter logWriter, 
            IMxpContractsRepository mxpContractsRepository, IMxpLeaseRepository mxpLeaseRepository, 
            IMxpServiceCallRepository mxpServiceCallRepository, ISharepointListService sharepointListService) : base(logWriter)
        {
            _mxpCustomerRepository = mxpCustomerRepository;
            _mxpContactRepository = mxpContactRepository;
            _mxpDeviceRepository = mxpDeviceRepository;
            _crmDeviceRepository = crmDeviceRepository;
            _mxpContractsRepository = mxpContractsRepository;
            _mxpLeaseRepository = mxpLeaseRepository;
            _sharepointListService = sharepointListService;
            _mxpServiceCallRepository = mxpServiceCallRepository;
        }

        async public Task<ResponseModel> SearchByCustomerNameAsync(string custName)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _mxpCustomerRepository.GetTableEntitiesAsync(custName, "");
                HasData = data.Any();
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No MXP customers found for {0}", custName), ResponseCode = HasData ? 200 : 204 };
            });
        }

        async public Task<ResponseModel> SearchByCustomerNumberAsync(string custNumber)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _mxpCustomerRepository.GetTableEntitiesAsync("", custNumber);
                HasData = data.Any();
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No MXP customers found for {0}", custNumber), ResponseCode = HasData ? 200 : 204 };
            });
        }

        async public Task<ResponseModel> GetCustomerAsync(string custNumber)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _mxpCustomerRepository.GetCustomerDetailAsync(custNumber);
                HasData = data != null;
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No MXP Customer found for {0}", custNumber), ResponseCode = HasData ? 200 : 404 };
            });
        }

        async public Task<ResponseModel> GetContactsSummaryAsync(string custNumber)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _mxpContactRepository.GetDetailEntitiesAsync(custNumber);
                HasData = data.Any();
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No MXP contacts found for Customer Number {0}", custNumber), ResponseCode = HasData ? 200 : 204 };
            });
        }

        async public Task<ResponseModel> GetDevicesByCustomerNumberAsync(string custNumber)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _mxpDeviceRepository.GetTableEntitiesAsync(custNumber);
                HasData = data.Any();
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No MXP devices found for Customer Number {0}", custNumber), ResponseCode = HasData ? 200 : 204 };
            });
        }

        async public Task<ResponseModel> GetDevicesByLeaseIdAsync(int leaseId)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _mxpDeviceRepository.GetTableEntitiesAsync(leaseId: leaseId);
                HasData = data.Any();
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No MXP devices found for lease id {0}", leaseId), ResponseCode = HasData ? 200 : 204 };
            });
        }

        async public Task<ResponseModel> GetDeviceBySysRefAsync(string systemRef)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _mxpDeviceRepository.GetDeviceDetailAsync(systemRef);
                HasData = data != null;
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No device found for System Ref {0}", systemRef), ResponseCode = HasData ? 200 : 404 };
            });

        }

        async public Task<ResponseModel> GetDeviceAndStatusBySysRefAsync(string systemRef)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _mxpDeviceRepository.GetDeviceDetailAsync(systemRef);
                if (data != null)
                {
                    var crmDevice = await _crmDeviceRepository.GetDeviceDetailBySysRefAsync(systemRef);
                    if (crmDevice == null)
                    {
                        data.CrmMxpStatus = CrmMxpStatus.DoesntExistInCrm;
                    }
                    else if (crmDevice.CustomerNumber != data.MxpCustomerNumber)
                    {
                        data.CrmMxpStatus = CrmMxpStatus.ExistsInCrmNotInMxp;
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

        async public Task<ResponseModel> GetContractHeadersByCustomerNumberAsync(string customerNumber)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _mxpContractsRepository.GetContractHeaderTableEntitiesAsync(customerNumber);
                HasData = data.Any();
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No contract headers found for customer number {0}", customerNumber), ResponseCode = HasData ? 200 : 204 };
            });
        }

        async public Task<ResponseModel> GetContractLinesByContractNumberAndCustomerNumberAsync(string contractNumber, string customerNumber)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _mxpContractsRepository.GetContractLinesTableEntitiesAsync(contractNumber,customerNumber);
                HasData = data != null;
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No contract lines found for contract number {0}", contractNumber), ResponseCode = HasData ? 200 : 204 };
            });
        }

        async public Task<ResponseModel> GetContractLineByCustomerNumberContractNumberAndLineNumberAsync(string customerNumber, string contractNumber, string lineNumber)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _mxpContractsRepository.GetContractLineDetailEntityAsync(customerNumber, contractNumber, lineNumber);
                HasData = data != null;
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No contract line found for customer number {0}", customerNumber), ResponseCode = HasData ? 200 : 404 };
            });
        }

        async public Task<ResponseModel> GetContractLineCategoriesByContractNumberAndLineNumberAsync(string contractNumber, string lineNumber)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _mxpContractsRepository.GetContractLineCategoryTableEntitiesAsync(contractNumber, Convert.ToDecimal(lineNumber));
                HasData = data != null;
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No contract line categories found for line number {0}", lineNumber), ResponseCode = HasData ? 200 : 204 };
            });
        }

        async public Task<ResponseModel> GetLeaseByLeaseIdAsync(int leaseId)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _mxpLeaseRepository.GetDetailEntitieAsync(leaseId);
                if (data != null && !string.IsNullOrWhiteSpace(data.Funder))
                {
                    data.Funder = _sharepointListService.GetFunderForCode(data.Funder);
                }
                HasData = data != null;
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No Lease found for Lease Id {0}", leaseId), ResponseCode = HasData ? 200 : 404 };
            });
        }

        async public Task<ResponseModel> GetLeasesByLeaseIdAsync(int leaseId)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _mxpLeaseRepository.GetDetailEntitieAsync(leaseId);
                if (data != null && !string.IsNullOrWhiteSpace(data.Funder))
                {
                    data.Funder = _sharepointListService.GetFunderForCode(data.Funder);
                }
                HasData = data != null;
                return new ResponseModel { Data = new[] {data}, Message = HasData ? string.Empty : string.Format("No Lease found for Lease Id {0}", leaseId), ResponseCode = HasData ? 200 : 404 };
            });
        }

        async public Task<ResponseModel> GetLeasesByCustomerNumberAsync(string customerNumber)
        {
            var funders = _sharepointListService.GetFunders();
            return await FecthDataAsync(async () =>
            {
                var data = await _mxpLeaseRepository.GetTableEntitiesAsync(customerNumber);
                foreach (var lease in data)
                {
                    if(!string.IsNullOrWhiteSpace(lease.Funder) && funders.ContainsKey(lease.Funder))
                            lease.Funder = funders[lease.Funder];
                    else
                    {
                        lease.Funder = "Awaiting Funder Info";
                    }
                }
                HasData = data.Any();
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No leases found for customer number {0}", customerNumber), ResponseCode = HasData ? 200 : 204 };
            });
        }

        async public Task<ResponseModel> SearchContractHeadersByContractNumberAsync(string contractNumber)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _mxpContractsRepository.SearchContractHeaderTableEntitiesAsync(contractNumber);
                HasData = data.Any();
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No contract headers found for contract number {0}", contractNumber), ResponseCode = HasData ? 200 : 204 };
            });
        }

        async public Task<ResponseModel> SearchLeasesByLeaseRefAsync(string leaseRef)
        {
            var funders = _sharepointListService.GetFunders();
            return await FecthDataAsync(async () =>
            {
                var data = await _mxpLeaseRepository.SearchTableEntitiesAsync(leaseRef);
                foreach (var lease in data)
                {
                    if (!string.IsNullOrWhiteSpace(lease.Funder) && funders.ContainsKey(lease.Funder))
                        lease.Funder = funders[lease.Funder];
                    else
                    {
                        lease.Funder = "Awaiting Funder Info";
                    }
                }
                HasData = data.Any();
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No leases found for lease reference {0}", leaseRef), ResponseCode = HasData ? 200 : 204 };
            });
        }

        async public Task<ResponseModel> GetServiceCallsByCustomerNumberStateStartDate(string customerNumber, string startDate, string endDate)
        {
            var start = DateTime.Parse(startDate);
            var end = DateTime.Parse(endDate);
            return await FecthDataAsync(async () =>
            {
                var data =
                    await
                        _mxpServiceCallRepository.GetTableEntitiesAsync(customerNumber, start, end);
                HasData = data.Any();
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No serice calls found for customer number {0}, from {1} to {2}", 
                    customerNumber, startDate, endDate), ResponseCode = HasData ? 200 : 204 };
            });
        }

        async public Task<ResponseModel> GetServiceCallsByCustomerNumberServiceNumber(string customerNumber, string serviceNumber)
        {
            return await FecthDataAsync(async () =>
            {
                var data =
                    await
                        _mxpServiceCallRepository.GetTableEntitiesAsync(customerNumber,serviceNumber:serviceNumber);
                HasData = data.Any();
                return new ResponseModel
                {
                    Data = data,
                    Message = HasData ? string.Empty : string.Format("No serice calls found for customer number {0}, and service number {1}",
                    customerNumber, serviceNumber),
                    ResponseCode = HasData ? 200 : 204
                };
            });
        }

        async public Task<ResponseModel> GetServiceCallByCustomerNumberServiceNumber(string customerNumber, string serviceNumber)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _mxpServiceCallRepository.GetDetailEntityAsync(serviceNumber, customerNumber);
                HasData = data != null;
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No service call found for service number {0}", serviceNumber), ResponseCode = HasData ? 200 : 404 };
            });
        }

        async public Task<ResponseModel> SearchServiceCallsByServiceNumberAsync(string serviceNumber)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _mxpServiceCallRepository.GetTableEntitiesAsync(serviceNumber:serviceNumber);
                HasData = data.Any();
                return new ResponseModel
                {
                    Data = data,
                    Message = HasData ? string.Empty :
                    string.Format("No MXP Service Calls found for service number {0}", serviceNumber),
                    ResponseCode = HasData ? 200 : 204
                };
            });
        }
    }
}