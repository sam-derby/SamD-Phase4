using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace BloodHound.AppWeb.Models
{
    public class ResponseModel
    {
        public int ResponseCode { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}