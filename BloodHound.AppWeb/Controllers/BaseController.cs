using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodHound.AppWeb.Interfaces.Services;
using BloodHound.AppWeb.Models;
using BloodHound.Core.Logging;
using Microsoft.SharePoint.Client;
using BloodHound.AppWeb.Services;
using Newtonsoft.Json;

namespace BloodHound.AppWeb.Controllers
{
    [Audit]
    public class BaseController : Controller
    {
        protected readonly IAuthorisationService AuthorisationService;

        public BaseController(IAuthorisationService authorisationService)
        {
            AuthorisationService = authorisationService;
        }

        [NonAction]
        protected ActionResult SerializeResponse(ResponseModel response)
        {
            if (response.Data == null)
                response.Data = string.Empty;
            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(response),
                ContentType = "application/json"
            };
        }
    }
}