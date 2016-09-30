using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BloodHound.AppWeb.Interfaces.Providers;
using BloodHound.AppWeb.Interfaces.Services;
using BloodHound.AppWeb.Utilities;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Search.Query;

namespace BloodHound.AppWeb.Services
{
    public class SharepointSearchService : ISharepointSearchService
    {
        private readonly ISharepointClientContextProvider _sharepointContextProvider;

        public SharepointSearchService(ISharepointClientContextProvider sharepointContextProvider)
        {
            _sharepointContextProvider = sharepointContextProvider;
        }

        public string GetCrmSiteUrl(string sharepointId)
        {
            using (var clientContext = _sharepointContextProvider.GetClientContext())
            {
                var keywordQuery = new KeywordQuery(clientContext) {QueryText = string.Format("contentclass:STS_Web {0}*", sharepointId) };

                var searchExecutor = new SearchExecutor(clientContext);

                var results = searchExecutor.ExecuteQuery(keywordQuery);
                clientContext.ExecuteQuery();

                var result = results.Value[0].ResultRows.FirstOrDefault();

                if (result != null)
                    return result["Path"].ToString();
                return string.Empty;
            }
        }
    }
}