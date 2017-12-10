using KingShipper.Data;
using KingShipper.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingShipper.Service.Services
{
    public static class UserBusinessService
    {
        public static List<UserBusiness> GetAll(int userId)
        {
            using (var uow = new UnitOfWork())
            {
                var lstUserBusiness = uow.UserBusinessRepository.FindAll(uB => uB.UserID == userId).ToList();
                return lstUserBusiness.Count > 0 ? lstUserBusiness : null;
            }
        }

        public static UserBusiness Add (UserBusiness userBusiness)
        {
            using (var uow = new UnitOfWork())
            {
                var uBusiness = uow.UserBusinessRepository.Add(userBusiness);
                return uBusiness;
            }
        }

        public static UserBusiness GetUserBusinessById(int userId, string businessId)
        {
            using (var uow = new UnitOfWork())
            {
                return uow.UserBusinessRepository.Find(uB => uB.UserID == userId && uB.BusinessID == businessId);
            }
        }

        public static UserBusiness Update(UserBusiness userBusiness)
        {
            using (var uow = new UnitOfWork())
            {
                var uBusiness = uow.UserBusinessRepository.Update(userBusiness);
                return uBusiness;
            }
        }


    }
}
