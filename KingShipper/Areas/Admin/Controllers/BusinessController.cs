using KingShipper.Areas.Admin.Models;
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
    public class BusinessController : Controller
    {

        HttpClient client;
        public BusinessController()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: Admin/Business
        public async Task<ActionResult> Index()
        {
            string url = Config.WebApiUrl + "/api/Business/GetAll";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            var responseData = new ResponseModel<Business>();
            if (responseMessage.IsSuccessStatusCode)
            {
                responseData = responseMessage.Content.ReadAsAsync<ResponseModel<Business>>().Result;
            }
            return this.View(responseData);
        }

        [HttpPost]
        public async Task<ActionResult> Update()
        {
            var reflectionController = new ReflectionController();
            var listController = new List<Type>();
            listController = reflectionController.GetController("KingShipper.Areas.Admin");

            string url = Config.WebApiUrl + "/api/Business/Update";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, listController);

            var responseData = new ResponseModel<Business>();
            if (responseMessage.IsSuccessStatusCode)
            {
                responseData = responseMessage.Content.ReadAsAsync<ResponseModel<Business>>().Result;
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}