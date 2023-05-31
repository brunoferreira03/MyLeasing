using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using MyLeasing.Web.Data.Entity;

namespace MyLeasing.Web.Data
{ 
    public class DataContext : DbContext
    {
        public DbSet<Owner> Owners { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
