using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BloodHound.AppWeb.Interfaces.Providers;
using BloodHound.AppWeb.Interfaces.Services;
using BloodHound.AppWeb.Models;
using BloodHound.AppWeb.Utilities;

namespace BloodHound.AppWeb.Services
{
    public class UserService : IUserService
    {
        readonly ISharepointClientContextProvider _clientContextProvider;

        public UserService(ISharepointClientContextProvider clientContextProvider)
        {
            _clientContextProvider = clientContextProvider;
        }

        public UserModel GetUserModel()
        {
            var clientContext = _clientContextProvider.GetClientContext();
            if (HttpContextSessionWrapper.UserModel == null)
            {
                var web = clientContext.Web;
                clientContext.Load(web);
                clientContext.Load(web.CurrentUser);
                clientContext.Load(web.CurrentUser.Groups);
                clientContext.ExecuteQuery();
                var groups = web.CurrentUser.Groups;
                HttpContextSessionWrapper.UserModel = new UserModel
                {
                    Email = web.CurrentUser.Email,
                    Title = web.CurrentUser.Title,
                    UserId = web.CurrentUser.LoginName,
                    Groups = groups.Select(m => m.LoginName).ToList()
                };
            }
            return HttpContextSessionWrapper.UserModel;
        }
    }
}