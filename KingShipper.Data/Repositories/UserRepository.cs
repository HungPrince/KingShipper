using KingShipper.Entity;

namespace KingShipper.Data.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(KingShipperContext context)
            : base(context)
        {

        }
    }
}
