using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodHound.AppWeb.Models;

namespace BloodHound.AppWeb.Interfaces.Services
{
    public interface IAuthorisationService
    {
        bool GetIsAuthrorised();

        AccessRights GetAccessRights();
    }
}
