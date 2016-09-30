using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;

namespace BloodHound.AppWeb.Interfaces.Utilities
{
    public interface ISessionWrapper
    {
        ClientContext SpClientContext { get; set; }
    }
}
