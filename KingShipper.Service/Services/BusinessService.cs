using KingShipper.Data;
using KingShipper.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingShipper.Service.Services
{
    public static class BusinessService
    {

        public static List<Business> GetAll()
        {
            using (var uow = new UnitOfWork())
            {
                if (uow.BusinessRepository.GetAll().Count() > 0)
                {
                    return uow.BusinessRepository.GetAll().ToList();
                }
            }
            return null;
        }

        public static Business GetBusinessById(string businessId)
        {
            using (var uow = new UnitOfWork())
            {
                var business = uow.BusinessRepository.Find(b => b.BusinessID == businessId);
                return business;
            }
        }

        public static Business AddBusiness(Business business)
        {
            using (var uow = new UnitOfWork())
            {
                if (business != null)
                {
                    return uow.BusinessRepository.Add(business);
                }
            }
            return null;
        }

        public static bool DeleteBusiness(Business business)
        {
            using (var uow = new UnitOfWork())
            {
                return (uow.BusinessRepository.Delete(business));
            }
        }
    }
}
