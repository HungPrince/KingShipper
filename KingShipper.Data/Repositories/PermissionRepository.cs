using KingShipper.Entity;

namespace KingShipper.Data.Repositories
{
    public class PermissionRepository : Repository<Permission>
    {
        public PermissionRepository(KingShipperContext context)
            : base(context)
        {

        }
    }
}
