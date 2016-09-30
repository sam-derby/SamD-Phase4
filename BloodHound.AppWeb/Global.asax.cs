using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BloodHound.AppWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutofacConfig.ConfigureContainer();
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            if (exception is HttpUnhandledException)
            {
                Server.Transfer("~/500Error.aspx");
            }
            if (exception != null)
            {
                Server.Transfer("~/500Error.aspx");
            }
            try
            {
                var app = sender as HttpApplication;
                app.Response.Filter = null;
            }
            catch
            {
                Server.Transfer("~/500Error.aspx");
            }
        }
    }
}
