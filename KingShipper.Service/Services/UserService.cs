using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingShipper.Entity;
using KingShipper.Data;

namespace KingShipper.Service.Services
{
    public class UserService
    {
        public static List<User> GetAll()
        {
            using (var uow = new UnitOfWork())
            {
                return uow.UserRepository.GetAll().ToList();
            }
        }

        public static bool CheckUser(User user)
        {
            using (var uow = new UnitOfWork())
            {
                if (uow.UserRepository.Find(u => u.UserName == user.UserName && u.Password == user.Password) != null)
                {
                    return true;
                }
                return false;
            }
        }

        public static User Add(User user)
        {
            using (var uow = new UnitOfWork())
            {
                if (user != null)
                {
                  return  uow.UserRepository.Add(user);
                }
                return null;
            }
        }
    }
}
