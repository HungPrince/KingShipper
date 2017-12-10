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
using KingShipper.Areas.Admin.Models;

namespace KingShipper.WebApi.Controllers
{
    [RoutePrefix("api/Business")]
    public class BusinessController : ApiController
    {
        Permission permission;
        Business business;
        // GET: Business
        public ResponseModel<Business> GetAll()
        {
            var response = new ResponseModel<Business>();
            var listBusiness = BusinessService.GetAll();
            if (listBusiness == null)
            {
                response.Status = ResponseStatus.Error.ToString();
                response.Message = "Empty";
            }
            else
            {
                response.DataList = listBusiness;
                response.Status = ResponseStatus.Success.ToString();
            }
            return response;
        }

        [HttpPost]
        public ResponseModel<Business> Update(List<Type> list)
        {
            var reflectionController = new ReflectionController();
            var response = new ResponseModel<Business>();

            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    business = new Business();
                    business.BusinessID = list[i].Name.ToString();
                    var businessDb = BusinessService.GetBusinessById(business.BusinessID);
                    if (businessDb != null)
                    {
                        if (business.BusinessID == businessDb.BusinessID)
                        {
                            var lstAction = reflectionController.GetActions(list[i]);
                            UpdatePermission(lstAction, list[i].Name.ToString());
                        }
                        else
                        {
                            var lstPermission = PermissionService.GetPermissionByBusinessId(business.BusinessID);
                            for (int j = 0; j < lstPermission.Count; j++)
                            {
                                PermissionService.Delete(lstPermission[i]);
                            }
                            BusinessService.DeleteBusiness(business);
                        }
                    }
                    else
                    {
                        business.Name = i.ToString();
                        try
                        {
                            BusinessService.AddBusiness(business);
                            var lstAction = reflectionController.GetActions(list[i]);
                            UpdatePermission(lstAction, list[i].Name.ToString());
                        }
                        catch (Exception e)
                        {
                            response.Status = ResponseStatus.Error.ToString();
                            response.Message = "error";
                            ExceptionHandler.Handle(e);
                        }
                    }
                }
                response.DataList = BusinessService.GetAll();
                response.Status = ResponseStatus.Success.ToString();
            }
            else
            {
                response.Status = ResponseStatus.Error.ToString();
                response.Message = "error";
            }
            return response;
        }

        private void UpdatePermission(List<string> lstAction, string businessId)
        {
            var actionName = "";
            if (lstAction.Count > 0)
            {
                for (int j = 0; j < lstAction.Count; j++)
                {
                    actionName = "";
                    actionName = businessId.Substring(0, businessId.Length - 10) + "-" + lstAction[j];
                    if (PermissionService.CheckExistsName(actionName))
                    {
                        continue;
                    }
                    permission = new Permission();
                    permission.BusinessID = businessId;
                    permission.Name = actionName;
                    permission.Description = "";
                    PermissionService.Add(permission);
                }
            }
        }
    }


}