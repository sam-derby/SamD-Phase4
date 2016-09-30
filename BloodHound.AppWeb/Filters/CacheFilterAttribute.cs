using System;
using System.Web;
using System.Web.Mvc;
using BloodHound.Core;

namespace BloodHound.AppWeb
{
    public class CacheFilterAttribute : ActionFilterAttribute
    {
        public int Duration{ get; set;}
        public CacheFilterAttribute()
        {
            Duration = Settings.Cache.Duration;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (Duration <= 0 || !Settings.Cache.EnableCache) return;

            var cache = filterContext.HttpContext.Response.Cache;
            var cacheDuration = TimeSpan.FromSeconds(Duration);

            cache.SetCacheability(HttpCacheability.Public);
            cache.SetExpires(DateTime.Now.Add(cacheDuration));
            cache.SetMaxAge(cacheDuration);
            cache.AppendCacheExtension("must-revalidate, proxy-revalidate");
        }
    }
}