using KingShipper.Library;
using KingShipper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using KingShipper.Entity;
using KingShipper.Areas.Admin.Models;

namespace KingShipper.Areas.Admin.Controllers
{
    [AuthorizeController]
    public class CategoryController : Controller
    {
        HttpClient client;
        public CategoryController()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            string url = Config.WebApiUrl + "/api/Category/GetAll";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            var responseData = new ResponseModel<Category>();
            if (responseMessage.IsSuccessStatusCode)
            {
                responseData = responseMessage.Content.ReadAsAsync<ResponseModel<Category>>().Result;
            }
            return this.View(responseData);
        }

        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpGet]

        public ActionResult Add()
        {
            return View();
        }

    }
}