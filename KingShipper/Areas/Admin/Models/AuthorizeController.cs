using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KingShipper.Areas.Admin.Models
{
    public class AuthorizeController : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var listpermission = (List<string>)HttpContext.Current.Session["Permission"];
            string actionName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName +
                "-" + filterContext.ActionDescriptor.ActionName;
            if (!listpermission.Contains(actionName))
            {
                filterContext.Result = new RedirectResult("~/Admin/Home/NotificationAuthorize");
            }
        }
    }
}