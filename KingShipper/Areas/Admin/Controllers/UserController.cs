﻿using KingShipper.Library;
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
    public class UserController : Controller
    {
        // GET: Admin/User
        HttpClient client;
        public UserController()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ActionResult> Index()
        {
            string url = Config.WebApiUrl + "/api/User/GetAll";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            var responseData = new ResponseModel<User>();
            if (responseMessage.IsSuccessStatusCode)
            {
                responseData = responseMessage.Content.ReadAsAsync<ResponseModel<User>>().Result;
            }
            return this.View(responseData);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new User();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(User model, FormCollection form)
        {
            model.RoleID = Int16.Parse(form["role"]);
            string url = Config.WebApiUrl + "/api/User/Add";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, model);
            var responseData = new ResponseModel<User>();
            if (responseMessage.IsSuccessStatusCode)
            {
                responseData = responseMessage.Content.ReadAsAsync<ResponseModel<User>>().Result;
                return RedirectToAction("Index");
            }
            return View(model);
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
    }
}