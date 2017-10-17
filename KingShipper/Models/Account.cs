using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KingShipper.Models
{
    public class Account
    {
        [AllowHtml]
        public string UserName { get; set; }
        public string Password { get; set; }

        public Account()
        {

        }
    }
}