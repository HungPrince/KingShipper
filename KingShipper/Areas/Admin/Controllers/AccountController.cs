using KingShipper.Library;
using KingShipper.Models;
using Microsoft.Security.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using KingShipper.Entity;
using KingShipper.Service.Services;

namespace KingShipper.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Login
        HttpClient client;
        public AccountController()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Login(Account model)
        {
            var username = Sanitizer.GetSafeHtmlFragment(model.UserName);
            string url = Config.WebApiUrl + "/api/User/Login";

            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, model);
            var responseData = new ResponseModel<Account>();
            if (responseMessage.IsSuccessStatusCode)
            {
                responseData = responseMessage.Content.ReadAsAsync<ResponseModel<Account>>().Result;
                if (responseData.Data != null)
                {
                    Session["User"] = responseData.Data;
                    Session["Role"] = responseData.Data.RoleId.ToString();
                    Session["Permission"] = GetListPermission(responseData.Data.Id);
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", responseData.Message);
            ViewBag.message = responseData.Message;
            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(User model)
        {
            string url = Config.WebApiUrl + "/api/User/Register";

            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, model);
            var responseData = new ResponseModel<User>();
            if (responseMessage.IsSuccessStatusCode)
            {
                responseData = responseMessage.Content.ReadAsAsync<ResponseModel<User>>().Result;
                if (responseData.Data != null)
                {
                    Session["User"] = responseData.Data;
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", responseData.Message);
            return View(model);
        }

        private List<string> GetListPermission(int userId)
        {
            var permissionName = "";
            var lstUPermission = UserPermissionService.GetAll(userId);
            var lstPermission = new List<string>();
            if (lstUPermission.Count > 0)
            {
                for (int i = 0; i < lstUPermission.Count; i++)
                {
                    permissionName = PermissionService.GetNameById(lstUPermission[i].PermissionID);
                    if (permissionName != "" && lstUPermission[i].Status == 1)
                    {
                        lstPermission.Add(permissionName);
                    }
                }
            }
            return lstPermission;
        }

    }
}