using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodHound.AppWeb.Utilities
{
    public class SharepointUtilities
    {
        public static void AddAppContextToViewBag(Controller controller, HttpContextBase httpContext, SharePointContext spContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            if (spContext == null)
                throw new ArgumentNullException("spContext");
            var viewBag = controller.ViewBag;
            viewBag.SPHostUrl = spContext.SPHostUrl.ToString().TrimEnd('/');
            viewBag.SPClientTag = spContext.SPClientTag;
            viewBag.SPLanguage = spContext.SPLanguage;
            viewBag.SPSourceUrl = httpContext.Request.QueryString["SPSourceUrl"] ?? string.Empty;
            viewBag.IsDialog = (httpContext.Request.QueryString["IsDlg"] != null) &&
                          (httpContext.Request.QueryString["IsDlg"].Substring(0, 1) == "1");
            viewBag.IsDialogParam = viewBag.IsDialog ? "1" : "0";
        }
    }
}