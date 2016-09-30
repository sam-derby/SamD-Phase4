using System.Web;
using System.Web.Mvc;

namespace BloodHound.AppWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new SharePointContextFilterAttribute(),1);
            filters.Add(new CompressAttribute(), 2);
            filters.Add(new BloodhoundErrorAttribute(),3);
        }
    }
}
