using KingShipper.Entity;

namespace KingShipper.Data.Repositories
{
    public class UserPermissionRepository : Repository<UserPermission>
    {
        public UserPermissionRepository(KingShipperContext context)
            : base(context)
        {

        }
    }
}
