using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BloodHound.AppWeb.Interfaces.Services;
using BloodHound.AppWeb.Interfaces.Services.Data;
using BloodHound.Core.Logging;
using BloodHound.Data.Interfaces.Repositories;

namespace BloodHound.AppWeb.Controllers
{
    [CacheFilter(Order = 3)]
    public class DeviceSearchDataController : BaseController
    {
        readonly IDeviceSearchDataService _deviceSearchDataService;

        public DeviceSearchDataController(IAuthorisationService authorisationService, 
            IDeviceSearchDataService deviceSearchDataService) 
            : base(authorisationService)
        {
            _deviceSearchDataService = deviceSearchDataService;
        }

        async public Task<ActionResult> SearchByCustomerNumber(string custNumber)
        {
            var response = await _deviceSearchDataService.SearchByCustomerNumberAsync(custNumber);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> SearchBySystemRef(string sysRef)
        {
            var response = await _deviceSearchDataService.SearchBySystemRefAsync(sysRef);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> SearchBySerialNumber(string serialNumber)
        {
            var response = await _deviceSearchDataService.SearchBySerialNumberAsync(serialNumber);
            return SerializeResponse(response);
        }

        async public Task<ActionResult> SearchByAlternativeReference(string altRef)
        {
            var response = await _deviceSearchDataService.SearchByAlternativeReferenceAsync(altRef);
            return SerializeResponse(response);
        }

       
        async public Task<ActionResult> SearchByLeaseId(int leaseId)
        {
            var data = await _deviceSearchDataService.SearchByLeaseIdAsync(leaseId);
            return SerializeResponse(data);
        }
    }
}