using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodHound.AppWeb.Interfaces.Providers;
using BloodHound.AppWeb.Interfaces.Services;
using BloodHound.AppWeb.Models;
using BloodHound.AppWeb.Utilities;
using BloodHound.Core;
using BloodHound.Core.Logging;

namespace BloodHound.AppWeb
{
    public class AuditAttribute : ActionFilterAttribute
    {
        readonly ILogWriter _logWriter;
        readonly IUserService _userService;

        public AuditAttribute()
        {
            _logWriter = DependencyResolver.Current.GetService<ILogWriter>();
            _userService = DependencyResolver.Current.GetService<IUserService>();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Settings.Logging.Audit)
            {
                var user = _userService.GetUserModel();
                _logWriter.LogAuditAsync
                    (LogType.ActionInvoked, user.Email,
                        filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                        filterContext.ActionDescriptor.ActionName, filterContext.ActionParameters.Values)
                    .ConfigureAwait(false);
            }
        }
    }
}