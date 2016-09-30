using BloodHound.AppWeb.Interfaces.Services;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using BloodHound.AppWeb.Interfaces.Providers;
using BloodHound.AppWeb.Models;
using BloodHound.AppWeb.Utilities;
using BloodHound.Core;

namespace BloodHound.AppWeb.Services
{
    public class AuthorisationService : IAuthorisationService
    {
        readonly ISharepointClientContextProvider _sharepointClientContextProvider;
        readonly IUserService _userService;

        public AuthorisationService(ISharepointClientContextProvider sharepointClientContextProvider, IUserService userService)
        {
            _sharepointClientContextProvider = sharepointClientContextProvider;
            _userService = userService;
        }

        public bool GetIsAuthrorised()
        {
            return IsBloodhoundUser();
        }

        bool IsBloodhoundUser()
        {
            var user = _userService.GetUserModel();

            if (Settings.Security.ApplyGroupCheck)
            {
                return user.Groups.FirstOrDefault(m => m == "Bloodhound") != null;
            }
            return true;
        }

        public AccessRights GetAccessRights()
        {
            var clientContext = _sharepointClientContextProvider.GetClientContext();
            var accessRights = new AccessRights();
            var web = clientContext.Web;
            clientContext.Load(web);
            clientContext.Load(web.CurrentUser);
            clientContext.Load(web.CurrentUser.Groups);
            clientContext.ExecuteQuery();

            var groups = web.CurrentUser.Groups;
            var isBloodhoundUser = groups.FirstOrDefault(m => m.LoginName == "Bloodhound") != null;
            if (!isBloodhoundUser)
                return accessRights;
            if (web.Title == "Finance")
                accessRights.IsFinance = true;
            return accessRights;
        }
    }
}