using MyLeasing.Web.Data.Entity;
using System.Linq;

namespace MyLeasing.Web.Data
{
    public interface ILesseeRepository : IGenericRepository<Lessee>
    {
        public IQueryable GetAllWithUsers();
    }
}
