using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using KingShipper.Models;
using KingShipper.Areas.Admin.Models;

namespace KingShipper.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["User"] == null)
            {
                return Redirect("http://localhost:64955/Admin/Account/Login");
            }
            var user = (Account)Session["User"];
            ViewBag.UserName = user.UserName;
         
            return View();
        }

        public ActionResult NotificationAuthorize()
        {
            return View();
        }
    }
}