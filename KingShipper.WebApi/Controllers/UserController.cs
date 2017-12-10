using System;
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
                //AddUserBusiness();
                //AddUserPermission();
                var userList = UserService.GetAll();
                response.DataList = userList;
                response.Status = ResponseStatus.Success.ToString();
                response.Message = "success";
            }
            catch (Exception e)
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
            //user.Avatar = "";
            try
            {
                user.Password = Utility.ToSHA512(user.Password);
                if (UserService.CheckUser(user) != null)
                {
                    response.Data = UserService.CheckUser(user);
                    response.Status = ResponseStatus.Success.ToString();
                }
            }
            catch (Exception e)
            {
                response.Status = ResponseStatus.Error.ToString();
                response.Message = "error";
                ExceptionHandler.Handle(e);
            }
            return response;
        }

        [HttpPost]
        public ResponseModel<User> Add(User user)
        {
            var response = new ResponseModel<User>();
            try
            {
                user.Password = Utility.ToSHA512(user.Password);
                if (UserService.Add(user) != null)
                {
                    response.Data = user;
                    response.Status = ResponseStatus.Success.ToString();
                }
                else
                {
                    response.Status = ResponseStatus.Error.ToString();
                    response.Message = "error";
                }
            }
            catch (Exception e)
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
                user.Password = Utility.ToSHA512(user.Password);
                if (UserService.Add(user) != null)
                {
                    response.Data = user;
                    response.Status = ResponseStatus.Success.ToString();
                }
                else
                {
                    response.Status = ResponseStatus.Error.ToString();
                    response.Message = "error";
                }
            }
            catch (Exception e)
            {
                response.Status = ResponseStatus.Error.ToString();
                response.Message = "error";
                ExceptionHandler.Handle(e);
            }
            return response;
        }



        private bool AddUserBusiness()
        {
            UserBusiness userBusiness;
            var listUser = UserService.GetAll();
            var listBusiness = BusinessService.GetAll();
            try
            {
                if (listUser.Count > 0)
                {
                    for (int i = 0; i < listUser.Count; i++)
                    {
                        userBusiness = new UserBusiness();
                        userBusiness.UserID = listUser[i].Id;
                        for (int j = 0; j < listBusiness.Count; j++)
                        {
                            userBusiness.BusinessID = listBusiness[j].BusinessID;
                            UserBusinessService.Add(userBusiness);
                        }
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        private bool AddUserPermission()
        {
            UserPermission userPermission;
            var listUser = UserService.GetAll();
            var listPermission = PermissionService.GetAll();
            try
            {
                if (listUser.Count > 0 && listPermission != null)
                {
                    for (int i = 0; i < listUser.Count; i++)
                    {
                        userPermission = new UserPermission();
                        userPermission.UserID = listUser[i].Id;
                        for (int j = 0; j < listPermission.Count; j++)
                        {
                            userPermission.PermissionID = listPermission[j].PermissionID;
                            UserPermissionService.Add(userPermission);
                        }
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return false;
        }
    }
}
