using KingShipper.Data;
using KingShipper.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingShipper.Service.Services
{
    public static class PermissionService
    {
        public static List<Permission> GetAll()
        {
            using (var uow = new UnitOfWork())
            {
                var listPermission = uow.PermissionRepository.GetAll().ToList();
                if (listPermission.Count > 0)
                {
                    return listPermission;
                }
            }
            return null;
        }

        public static string GetNameById(int Id)
        {
            using (var uow = new UnitOfWork())
            {
                var permission = uow.PermissionRepository.Find(u => u.PermissionID == Id);
                return permission != null ? permission.Name : "";
            }
        }

        public static List<Permission> GetPermissionByBusinessId(string businessID)
        {
            using (var uow = new UnitOfWork())
            {
                var listPermission = uow.PermissionRepository.FindAll(p => p.BusinessID == businessID).ToList();
                if(listPermission.Count > 0)
                {
                    return listPermission;
                }
            }
            return null;
        }

        public static Permission Add(Permission permission)
        {
            using (var uow = new UnitOfWork())
            {
                var per = uow.PermissionRepository.Add(permission);
                if(per != null)
                {
                    return per;
                }
            }
            return null;
        }

        public  static bool Delete(Permission permission)
        {
            using (var uow = new UnitOfWork())
            {
                return uow.PermissionRepository.Delete(permission);
            }
        }

        public static bool CheckExistsName(string permissionName)
        {
            using (var uow = new UnitOfWork())
            {
                var per = uow.PermissionRepository.Find(p => p.Name == permissionName);
                return per != null ? true : false;
            }
        }
    }
}
