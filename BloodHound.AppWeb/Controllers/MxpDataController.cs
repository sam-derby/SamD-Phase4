using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using BloodHound.AppWeb.Interfaces.Services;
using BloodHound.AppWeb.Interfaces.Services.Data;
using BloodHound.AppWeb.Models;
using BloodHound.AppWeb.Services.Data;
using BloodHound.Core.Logging;
using BloodHound.Data;
using BloodHound.Data.Entities.Mxp.Table;
using BloodHound.Data.Enums;
using BloodHound.Data.Interfaces.Repositories;
using Newtonsoft.Json;

namespace BloodHound.AppWeb.Controllers
{
    [CacheFilter(Duration = 60, Order = 3)]
    public class MxpDataController : BaseController
    {
        readonly IMxpDataService _mxpDataService;


        public MxpDataController(IAuthorisationService authorisationService, 
            IMxpDataService mxpDataService) 
            : base(authorisationService)
        {
            _mxpDataService = mxpDataService;
        }

        async public Task<ActionResult> SearchByCustomerName(string custName)
        {
            var response = await _mxpDataService.SearchByCustomerNameAsync(custName);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> SearchByCustomerNumber(string custNumber)
        {
            var response = await _mxpDataService.SearchByCustomerNumberAsync(custNumber);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> GetCustomer(string custNumber)
        {
            var response = await _mxpDataService.GetCustomerAsync(custNumber);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> GetContactsSummary(string custNumber)
        {
            var response = await _mxpDataService.GetContactsSummaryAsync(custNumber);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> GetDevicesByCustomerNumber(string custNumber)
        {
            var response = await _mxpDataService.GetDevicesByCustomerNumberAsync(custNumber);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> GetDevicesByLeaseId(int leaseId)
        {
            var response = await _mxpDataService.GetDevicesByLeaseIdAsync(leaseId);
            return SerializeResponse(response);
        }
       
        async public Task<ActionResult> GetDeviceBySysRef(string systemRef)
        {
            var response = await _mxpDataService.GetDeviceBySysRefAsync(systemRef);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> GetDeviceAndStatusBySysRef(string systemRef)
        {
            var response = await _mxpDataService.GetDeviceAndStatusBySysRefAsync(systemRef);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> GetContractHeadersByCustomerNumber(string customerNumber)
        {
            var response = await _mxpDataService.GetContractHeadersByCustomerNumberAsync(customerNumber);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> GetContractLinesByContractNumberAndCustomerNumber(string contractNumber, string customerNumber)
        {
            var response =
                await
                    _mxpDataService.GetContractLinesByContractNumberAndCustomerNumberAsync(contractNumber,
                        customerNumber);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> GetContractLineCategoriesByContractNumberAndLineNumber(string contractNumber, string lineNumber)
        {
            var response =
                await
                    _mxpDataService.GetContractLineCategoriesByContractNumberAndLineNumberAsync(contractNumber,
                        lineNumber);
            return SerializeResponse(response);
        }
        async public Task<ActionResult> GetContractLineByCustomerNumberContractNumberAndLineNumber(string customerNumber, string contractNumber, string lineNumber)
        {
            var response =
                await
                    _mxpDataService.GetContractLineByCustomerNumberContractNumberAndLineNumberAsync(customerNumber,contractNumber,
                        lineNumber);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> GetLeasesByCustomerNumber(string customerNumber)
        {
            var response =
                await
                    _mxpDataService.GetLeasesByCustomerNumberAsync(customerNumber);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> GetLeasesByLeaseId(int leaseId)
        {
            var response =
                await
                    _mxpDataService.GetLeaseByLeaseIdAsync(leaseId);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> GetLeaseListByLeaseId(int leaseId)
        {
            var response =
                await
                    _mxpDataService.GetLeasesByLeaseIdAsync(leaseId);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> SearchContractsByContractNumber(string contractNumber)
        {
            var response =
                await
                    _mxpDataService.SearchContractHeadersByContractNumberAsync(contractNumber);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> SearchLeasesByLeaseRef(string leaseRef)
        {
            var response =
                await
                    _mxpDataService.SearchLeasesByLeaseRefAsync(leaseRef);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> GetServiceCalls(string customerNumber, string startDate, string endDate)
        {
            var response =
                await
                    _mxpDataService.GetServiceCallsByCustomerNumberStateStartDate(customerNumber, startDate, endDate);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> GetServiceCallsWithServiceNumber(string customerNumber, string serviceNumber)
        {
            var response =
                await
                    _mxpDataService.GetServiceCallsByCustomerNumberServiceNumber(customerNumber, serviceNumber);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> GetServiceCall(string customerNumber, string serviceNumber)
        {
            var response =
                await
                    _mxpDataService.GetServiceCallByCustomerNumberServiceNumber(customerNumber, serviceNumber);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> SearchServiceCallsByServiceNumber(string customerNumber)
        {
            var response =
                await
                    _mxpDataService.SearchServiceCallsByServiceNumberAsync(customerNumber);
            return SerializeResponse(response);
        }

        public ActionResult KeepAlive(string id)
        {
            var response = new ResponseModel
            {
                Data = "Alive",
                ResponseCode = 200
            };
            return SerializeResponse(response);
        }
    }
}