using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodHound.AppWeb.Interfaces.Services;
using System.Web.Mvc;
using BloodHound.Core.Logging;

namespace BloodHound.AppWeb.Controllers
{
    public class HomeController : Controller
    {
       readonly IAuthorisationService _authorisationService;
        private readonly IUserService _userService;
        readonly ILogWriter _logWriter;

        public HomeController(IAuthorisationService authorisationService, ILogWriter logWriter, IUserService userService)
        {
            _authorisationService = authorisationService;
            _userService = userService;
            _logWriter = logWriter;
        }

        [SharePointContextFilter]
        async public Task<ActionResult> Index()
        {
            var isAuthorised = _authorisationService.GetIsAuthrorised();
            var user = _userService.GetUserModel();
            if (Core.Settings.Logging.Audit)
            {
                await _logWriter.LogAuditAsync(LogType.UserApplicationStart, user.Email, "User accessed application");
                if (!isAuthorised)
                {
                    await _logWriter.LogAuditAsync(LogType.NonBloodHoundUserAccess, user.Email, "User tried to access the application when not in the bloodhound group");
                }
            }
            return !isAuthorised ? View("403Error") : View();
        }

    }
}