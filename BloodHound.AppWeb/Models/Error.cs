using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace BloodHound.AppWeb.Models
{
    public class Error
    {
        public Error(int errorCode, string message)
        {
            ErrorCode = errorCode;
            Message = message;
            LogId = Guid.NewGuid().ToString();
        }
        public string LogId { get; private set; }
        public int ErrorCode { get; set; }
        public string Message { get; set; }
    }
}