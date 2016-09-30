using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BloodHound.AppWeb.Interfaces.Utilities;
using BloodHound.AppWeb.Models;
using Microsoft.SharePoint.Client;

namespace BloodHound.AppWeb.Utilities
{
    static public class HttpContextSessionWrapper
    {
        static T GetFromSession<T>(string key)
        {
            return (T)HttpContext.Current.Session[key];
        }

        static void SetInSession(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }

        static public ClientContext SpClientContext
        {
            get { return GetFromSession<ClientContext>("SPClientContext"); }
            set { SetInSession("SPClientContext", value); }
        }

        static public UserModel UserModel
        {
            get { return GetFromSession<UserModel>("UserModel"); }
            set { SetInSession("UserModel", value); }
        }
    }
}