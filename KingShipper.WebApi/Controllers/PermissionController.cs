using KingShipper.Constant;
using KingShipper.Entity;
using KingShipper.Service.Services;
using System.Web.Http;
using KingShipper.WebApi.Models;


namespace KingShipper.WebApi.Controllers
{
    [RoutePrefix("api/Permission")]
    public class PermissionController : ApiController
    {
        // GET: Permission

        [HttpGet]
        public ResponseModel<Permission> GetAll()
        {
            var response = new ResponseModel<Permission>();
            var listPer = PermissionService.GetAll();
            response.DataList = listPer;
            return response;
        }

        [HttpGet]
        public ResponseModel<Permission> GetAllByBusinessId(string businessId)
        {
            var response = new ResponseModel<Permission>();
            var listPer = PermissionService.GetPermissionByBusinessId(businessId);
            response.DataList = listPer;
            return response;
        }
    }
}