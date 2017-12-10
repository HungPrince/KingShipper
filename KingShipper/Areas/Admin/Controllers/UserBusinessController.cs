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
using System.Web.Helpers;

namespace KingShipper.Areas.Admin.Controllers
{
    public class UserBusinessController : Controller
    {
        HttpClient client;
        public UserBusinessController()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: Admin/UserBusiness
        [HttpGet]
        public async Task<ActionResult> Index(int userId)
        {
            string url = Config.WebApiUrl + "/api/UserBusiness/GetAll?userId=" + userId;
            TempData["UserRoleID"] = userId;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            var responseData = new ResponseModel<UserBusiness>();
            if (responseMessage.IsSuccessStatusCode)
            {
                responseData = responseMessage.Content.ReadAsAsync<ResponseModel<UserBusiness>>().Result;
            }
            return this.View(responseData);
        }

        [HttpPost]
        public async Task<ActionResult> Update(string businessId)
        {
            int userId = int.Parse(TempData["UserRoleID"].ToString());
            var userBusiness = UserBusinessService.GetUserBusinessById(userId, businessId);
            if (userBusiness.Status == null || userBusiness.Status == 0)
            {
                userBusiness.Status = 1;
            }
            else
            {
                userBusiness.Status = 0;
            }
            string url = Config.WebApiUrl + "/api/UserBusiness/Update";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, userBusiness);
            var responseData = new ResponseModel<UserBusiness>();
            if (responseMessage.IsSuccessStatusCode)
            {
                responseData = responseMessage.Content.ReadAsAsync<ResponseModel<UserBusiness>>().Result;
                return Json(new { status = "true" });
            }
            return Json(new { status = "false" });
        }
    }
}