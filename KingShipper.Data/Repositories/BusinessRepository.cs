using KingShipper.Entity;

namespace KingShipper.Data.Repositories
{
    public class BusinessRepository : Repository<Business>
    {
        public BusinessRepository(KingShipperContext context)
            : base(context)
        {

        }
    }
}
