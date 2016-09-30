using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BloodHound.AppWeb.Interfaces.Services;
using BloodHound.AppWeb.Interfaces.Services.Data;
using BloodHound.AppWeb.Services;
using BloodHound.AppWeb.Services.Data;
using BloodHound.Core.Logging;
using BloodHound.Data;
using BloodHound.Data.Entities.Crm.Table;
using BloodHound.Data.Interfaces.Repositories;

namespace BloodHound.AppWeb.Controllers
{
    [CacheFilter(Order = 3)]
    public class CrmDataController : BaseController
    {
        readonly ICrmDataService _crmDataService;
        readonly ICrmOpportunityDataService _crmOpportunityDataService;

        public CrmDataController(IAuthorisationService authorisationService,
            ICrmDataService crmDataService, ICrmOpportunityDataService crmOpportunityDataService) 
            : base(authorisationService)
        {
            _crmDataService = crmDataService;
            _crmOpportunityDataService = crmOpportunityDataService;
        }

        [CacheFilter(Duration = 60, Order = 3)]
        async public Task<ActionResult> SearchByCustomerName(string accountName)
        {
            var response = await _crmDataService.SearchByCustomerNameAsync(accountName);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> GetAccount(string accountNumber)
        {
            var response = await _crmDataService.GetAccountAsync(accountNumber);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> GetMxpCrmRecords(string custNumber)
        {
            var response = await _crmDataService.GetMxpCrmRecordsAsync(custNumber);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> GetCrmContacts(string accountNumber)
        {
            var response = await _crmDataService.GetCrmContactsAsync(accountNumber);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> GetCrmDevicesByMxpCustomerNumber(string customerNumber)
        {
            var response = await _crmDataService.GetCrmDevicesByMxpCustomerNumberAsync(customerNumber);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> GetDevicesByAccountNumber(string accountNumber)
        {
            var response = await _crmDataService.GetDevicesByAccountNumberAsync(accountNumber);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> GetDeviceByDeviceId(string deviceId)
        {
            var response = await _crmDataService.GetDeviceByDeviceIdAsync(deviceId);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> GetDeviceBySysRef(string systemRef)
        {
            var response = await _crmDataService.GetDeviceBySysRefAsync(systemRef);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> GetDeviceAndStatusBySysRef(string systemRef)
        {
            var response = await _crmDataService.GetDeviceAndStatusBySysRefAsync(systemRef);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> SearchOpportunitiesByOpportunityNumber(string oppNumber)
        {
            var response = await _crmOpportunityDataService.SearchOpportunitiesByOppNumberAsync(oppNumber);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> GetOpportunities(string accountNumber,string state, string startDate, string endDate)
        {
            var response =
                await
                    _crmOpportunityDataService.GetOpportunitiesByStateAccountNumberAndStartDateAndEndDateAsync(state,
                        accountNumber, startDate, endDate);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> GetOpportunitiesWithOppNumber(string accountNumber, string oppNumber)
        {
            var response =
                await
                    _crmOpportunityDataService.GetOpportunitiesByOppNumberAccountNumberAsync(oppNumber, accountNumber);
            return SerializeResponse(response);
        }
    }
}