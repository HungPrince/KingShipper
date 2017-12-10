using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KingShipper.WebApi.Models
{
    public class UserPermissionModel
    {
        public int UserID { get; set; }
        public int PermissionID { get; set; }
        public string NameAction { get; set; }
        public short? Status { get; set; }
    }
}