using System.Web.Http;
using KingShipper.WebApi.Models;
using KingShipper.Entity;
using KingShipper.Service.Services;
using KingShipper.Constant;
using KingShipper.Library;
namespace KingShipper.WebApi.Controllers
{
    [RoutePrefix("api/UserBusiness")]
    public class UserBusinessController : ApiController
    {
        // GET: UserBusiness
        [HttpGet]
        public ResponseModel<UserBusiness> GetAll(int userId)
        {
            var response = new ResponseModel<UserBusiness>();
            var lstUBusiness = UserBusinessService.GetAll(userId);
            response.DataList = lstUBusiness;
            response.Message = "Success";
            response.Status = ResponseStatus.Success.ToString();
            return response;
        }

        [HttpPost]
        public ResponseModel<UserBusiness> Update(UserBusiness userBusiness)
        {
            var response = new ResponseModel<UserBusiness>();
            if (userBusiness != null)
            {
                UserBusinessService.Update(userBusiness);
                response.Data = userBusiness;
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