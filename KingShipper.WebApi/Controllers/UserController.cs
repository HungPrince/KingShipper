using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using KingShipper.WebApi.Models;
using KingShipper.Entity;
using KingShipper.Service.Services;
using KingShipper.Constant;
using KingShipper.Library;

namespace KingShipper.WebApi.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        [HttpGet]
        public ResponseModel<User> GetAll()
        {
            var response = new ResponseModel<User>();
            try
            {
                var userList = UserService.GetAll();
                response.DataList = userList;
                response.Status = ResponseStatus.Success.ToString();
                response.Message = "success";
            }
            catch(Exception e)
            {
                response.Status = ResponseStatus.Error.ToString();
                response.Message = "error";
                ExceptionHandler.Handle(e);
            }
            return response;
        }

        [HttpPost]
       
        public ResponseModel<User> Login(User user)
        {
            var response = new ResponseModel<User>();
            try
            {
                user.Password = Utility.ToSHA512(user.Password);
                if (UserService.CheckUser(user))
                {
                    response.Data = user;
                    response.Status = ResponseStatus.Success.ToString();
                }
            }catch(Exception e)
            {
                response.Status = ResponseStatus.Error.ToString();
                response.Message = "error";
                ExceptionHandler.Handle(e);
            }
            return response;
        }

        [HttpPost]
        
        public ResponseModel<User> Register(User user)
        {
            var response = new ResponseModel<User>();
            try
            {
                if(UserService.Add(user) != null)
                {
                    response.Data = user;
                    response.Status = ResponseStatus.Success.ToString();
                }
                else
                {
                    response.Status = ResponseStatus.Error.ToString();
                    response.Message = "error";
                }
            }catch(Exception e)
            {
                response.Status = ResponseStatus.Error.ToString();
                response.Message = "error";
                ExceptionHandler.Handle(e);
            }
            return response;
        }
    }
}
