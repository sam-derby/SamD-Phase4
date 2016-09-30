using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BloodHound.AppWeb.Interfaces.Providers;
using Microsoft.SharePoint.Client;

namespace BloodHound.AppWeb.Providers
{
    public class SharepointClientContextProvider : ISharepointClientContextProvider
    {
        public ClientContext GetClientContext()
        {
            var httpContext = HttpContext.Current;
            var spContext = (SharePointAcsContext)SharePointContextProvider.Current.GetSharePointContext(httpContext);
            return spContext.CreateUserClientContextForSPHost();
        }
    }
}