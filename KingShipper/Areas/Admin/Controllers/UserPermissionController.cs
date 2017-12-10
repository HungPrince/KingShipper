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
using KingShipper.Areas.Admin.Models;

namespace KingShipper.Areas.Admin.Controllers
{
    public class UserPermissionController : Controller
    {
        HttpClient client;
        public UserPermissionController()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: Admin/UserBusiness
        [HttpGet]
        public async Task<ActionResult> Index(int userId)
        {
            string url = Config.WebApiUrl + "/api/UserPermission/GetAll?userId=" + userId;
            Session["UserRoleID"] = userId;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            var responseData = new ResponseModel<UserPermissionModel>();
            if (responseMessage.IsSuccessStatusCode)
            {
                responseData = responseMessage.Content.ReadAsAsync<ResponseModel<UserPermissionModel>>().Result;
            }
            return this.View(responseData);
        }

        [HttpPost]
        public async Task<ActionResult> Update(int permissionId)
        {
            int userId = int.Parse(Session["UserRoleID"].ToString());
            var userPermission = UserPermissionService.GetUserPermissionById(userId, permissionId);
            if (userPermission.Status == null || userPermission.Status == 0)
            {
                userPermission.Status = 1;
            }
            else
            {
                userPermission.Status = 0;
            }
            string url = Config.WebApiUrl + "/api/UserPermission/Update";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, userPermission);
            var responseData = new ResponseModel<UserPermission>();
            if (responseMessage.IsSuccessStatusCode)
            {
                responseData = responseMessage.Content.ReadAsAsync<ResponseModel<UserPermission>>().Result;
                return Json(new { status = "true" });
            }
            return Json(new { status = "false" });
        }
    }
}