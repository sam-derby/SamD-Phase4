using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.UserProfiles;

namespace BloodHound.AppWeb.Services
{
    public class SharepointProfileService
    {
        public IDictionary<string, string> GetUserProfile(ClientContext clientContext)
        {
            var peopleManager = new PeopleManager(clientContext);
            var personProperties = peopleManager.GetMyProperties();
            clientContext.Load(personProperties);
            clientContext.ExecuteQuery();

            return personProperties.UserProfileProperties;

        } 
    }
}