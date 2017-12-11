using KingShipper.Entity;

namespace KingShipper.Data.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(KingShipperContext context)
            : base(context)
        {

        }
    }
}
