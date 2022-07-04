using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class LoginModel
    {
        public string Email { get; set; }

        public string PassCode { get; set; }

        public bool IsUsingPhone { get; set; }

        public string RedirectLink { get; set; }
    }
}