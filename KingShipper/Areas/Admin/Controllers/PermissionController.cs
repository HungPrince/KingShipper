using KingShipper.Entity;
using KingShipper.Library;
using KingShipper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KingShipper.Areas.Admin.Controllers
{
    public class PermissionController : Controller
    {
        HttpClient client;
        public PermissionController()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: Admin/Permission
        [HttpGet]
        public async Task<ActionResult> Index(string businessId)
        {
            string url = Config.WebApiUrl + "/api/Permission/GetAllByBusinessId?businessId=" + businessId;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            var responseData = new ResponseModel<Permission>();
            if (responseMessage.IsSuccessStatusCode)
            {
                responseData = responseMessage.Content.ReadAsAsync<ResponseModel<Permission>>().Result;
            }
            return this.View(responseData);
        }
    }
}