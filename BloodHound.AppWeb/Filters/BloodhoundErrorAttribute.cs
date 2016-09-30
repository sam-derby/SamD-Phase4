using System;
using System.Web.Helpers;
using System.Web.Mvc;
using BloodHound.AppWeb.Models;
using BloodHound.Core.Logging;
using Newtonsoft.Json;

namespace BloodHound.AppWeb
{
    public class BloodhoundErrorAttribute : HandleErrorAttribute
    {
        private readonly ILogWriter _logWriter;

        public BloodhoundErrorAttribute()
        {
            _logWriter = DependencyResolver.Current.GetService<ILogWriter>();
        }

        public override void OnException(ExceptionContext filterContext)
        {
            var exception = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            var id = Guid.NewGuid();
            //_logWriter.LogUnHandledledErrorAsync(id, exception)
            //    .ConfigureAwait(false);

            filterContext.Result = new ContentResult
            {
                Content = JsonConvert.SerializeObject(new ResponseModel {ResponseCode = 500, Message = 
                        string.Format("Huh, Well that wasn't supposed to happen, please try again if the problem persists, please contact support with the following id {0}", id.ToString())}),
                ContentType = "application/json"
            }; 
            base.OnException(filterContext);
        }
    }
}