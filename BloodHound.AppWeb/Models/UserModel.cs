using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodHound.AppWeb.Models
{
    public class UserModel
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Groups { get; set; }

        public UserModel()
        {
            Groups = Enumerable.Empty<string>();
        }
    }
}