using KingShipper.Entity;

namespace KingShipper.Data.Repositories
{
    public class UserBusinessRepository : Repository<UserBusiness>
    {
        public UserBusinessRepository(KingShipperContext context)
            : base(context)
        {

        }
    }
}
