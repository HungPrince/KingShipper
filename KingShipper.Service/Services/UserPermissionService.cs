using KingShipper.Data;
using KingShipper.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingShipper.Service.Services
{
    public static class UserPermissionService
    {
        public static List<UserPermission> GetAll(int userId)
        {
            using (var uow = new UnitOfWork())
            {
                var lstUserPermission = uow.UserPermissionRepository.FindAll(uP=>uP.UserID == userId).ToList();
                return lstUserPermission.Count > 0 ? lstUserPermission : null;
            }
        }

        public static UserPermission GetUserPermissionById(int userId, int permisionId)
        {
            using (var uow = new UnitOfWork())
            {
                return uow.UserPermissionRepository.Find(uP => uP.UserID == userId && uP.PermissionID == permisionId);
            }
        }

        public static UserPermission Add(UserPermission userPermission)
        {
            using (var uow = new UnitOfWork())
            {
                return uow.UserPermissionRepository.Add(userPermission);
            }
        }

        public static UserPermission Update(UserPermission userPermission)
        {
            using (var uow = new UnitOfWork())
            {
                var uPermission= uow.UserPermissionRepository.Update(userPermission);
                return uPermission;
            }
        }
    }
}
