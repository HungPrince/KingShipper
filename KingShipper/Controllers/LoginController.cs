using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

using KingShipper.Library;
using KingShipper.Models;

namespace KingShipper.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        HttpClient client;
        public LoginController()
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
        public async Task<ActionResult> Login(Account model)
        {
            string url = Config.WebApiUrl + "/api/User/Login";

            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, model);
            var responseData = new ResponseModel<Account>();
            if (responseMessage.IsSuccessStatusCode)
            {
                responseData = responseMessage.Content.ReadAsAsync<ResponseModel<Account>>().Result;
                if(responseData.Data != null)
                {
                    Session["UserName"] = responseData.Data.UserName;
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", responseData.Message);
            ViewBag.message = responseData.Message;
            return View(model);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}