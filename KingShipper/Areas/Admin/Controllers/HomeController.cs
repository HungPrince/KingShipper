using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using KingShipper.Models;

namespace KingShipper.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var user = (Account)Session["user"];
            ViewBag.UserName = user.UserName;
            return View();
        }
    }
}