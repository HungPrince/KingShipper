using KingShipper.Data;
using KingShipper.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingShipper.Service.Services
{
    public static class  CategoryService
    {
        public static List<Category> GetAll()
        {
            using (var uow = new UnitOfWork())
            {
                return uow.CategoryRepository.GetAll().ToList();
            }
        }
    }
}
