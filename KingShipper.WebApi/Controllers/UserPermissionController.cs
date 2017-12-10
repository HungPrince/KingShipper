using System.Web.Http;
using KingShipper.WebApi.Models;
using KingShipper.Entity;
using KingShipper.Service.Services;
using KingShipper.Constant;
using KingShipper.Library;
using System.Collections.Generic;

namespace KingShipper.WebApi.Controllers
{
    [RoutePrefix("api/UserPermission")]
    public class UserPermissionController : ApiController
    {
        // GET: UserPermission
        [HttpGet]
        public ResponseModel<UserPermissionModel> GetAll(int userId)
        {
            UserPermissionModel userPermission;
            var lstUserPemissionModel = new List<UserPermissionModel>();
            var response = new ResponseModel<UserPermissionModel>();
            var lstUPermission = UserPermissionService.GetAll(userId);
            for (int i = 0; i < lstUPermission.Count; i++)
            {
                userPermission = new UserPermissionModel();
                userPermission.NameAction = PermissionService.GetNameById(lstUPermission[i].PermissionID);
                userPermission.UserID = lstUPermission[i].UserID;
                userPermission.Status = lstUPermission[i].Status;
                userPermission.PermissionID = lstUPermission[i].PermissionID;
                lstUserPemissionModel.Add(userPermission);
            }
            response.DataList = lstUserPemissionModel;
            response.Message = "Success";
            response.Status = ResponseStatus.Success.ToString();
            return response;
        }

        [HttpPost]
        public ResponseModel<UserPermission> Update(UserPermission userPermission)
        {
            var response = new ResponseModel<UserPermission>();
            if (userPermission != null)
            {
                UserPermissionService.Update(userPermission);
                response.Data = userPermission;
                response.Status = ResponseStatus.Success.ToString();
            }
            else
            {
                response.Status = ResponseStatus.Error.ToString();
                response.Message = "Fail";
            }
            return response;
        }
    }
}