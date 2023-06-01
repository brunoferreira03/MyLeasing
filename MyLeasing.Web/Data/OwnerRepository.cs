using MyLeasing.Web.Data.Entity;

namespace MyLeasing.Web.Data
{
    public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
    {
        public OwnerRepository(DataContext context) : base (context)
        {

        }
    }
}
