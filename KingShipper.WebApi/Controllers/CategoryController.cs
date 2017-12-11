using KingShipper.Constant;
using KingShipper.Entity;
using KingShipper.Models;
using KingShipper.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KingShipper.WebApi.Controllers
{
    [RoutePrefix("api/Category")]
    public class CategoryController : ApiController
    {
        public ResponseModel<Category> GetAll()
        {
            var response = new ResponseModel<Category>();
            var lstCategory = CategoryService.GetAll();
            response.DataList = lstCategory;
            response.Status = ResponseStatus.Success.ToString();
            return response;
        }
    }
}
