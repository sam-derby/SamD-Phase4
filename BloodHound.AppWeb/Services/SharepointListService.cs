using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BloodHound.AppWeb.Interfaces.Providers;
using BloodHound.AppWeb.Interfaces.Services;
using Microsoft.SharePoint.Client;

namespace BloodHound.AppWeb.Services
{
    public class SharepointListService : ISharepointListService
    {
        readonly ISharepointClientContextProvider _clientContextProvider;

        public SharepointListService(ISharepointClientContextProvider clientContextProvider)
        {
            _clientContextProvider = clientContextProvider;
        }

        public string GetFunderForCode(string code)
        {
            var clientContext = _clientContextProvider.GetClientContext();
            var funderList = clientContext.Web.Lists.GetByTitle("Funders");
            var camlQuery = new CamlQuery
            {
                ViewXml =
                    "<View><Query><Where><Eq><FieldRef Name='Code'/><Value Type='Text'>" + code +
                    "</Value></Eq></Where></Query><RowLimit>1</RowLimit></View>"
            };
            var collList= funderList.GetItems(camlQuery);
            clientContext.Load(collList);
            clientContext.ExecuteQuery();
            if(collList.Count == 1)
                return collList[0]["Title"].ToString();
            return "Awaiting Funder Info";
        }

        public Dictionary<string,string> GetFunders()
        {
            var clientContext = _clientContextProvider.GetClientContext();
            var funderList = clientContext.Web.Lists.GetByTitle("Funders");
            var camlQuery = CamlQuery.CreateAllItemsQuery();
            var collList = funderList.GetItems(camlQuery);
            clientContext.Load(collList);
            clientContext.ExecuteQuery();
            var funders = new Dictionary<string, string>();
            foreach (var item in collList)
            {
                funders.Add(item["Code"].ToString(), item["Title"].ToString());
            }
            return funders;
        }
    }
}