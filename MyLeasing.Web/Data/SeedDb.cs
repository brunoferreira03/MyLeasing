using MyLeasing.Web.Data.Entity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private Random r;

        public SeedDb(DataContext context)
        {
           _context = context;
            r = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if (!_context.Owners.Any())
            {
                for (int i = 0; i < 10; i++)
                {
                    seedOwners(i);
                }
                await _context.SaveChangesAsync();
            }
        }

        private void seedOwners(int i)
        {
            //[Bind("Id,Document,Name,Fixed_Phone,Cell_Phone,Address")]
            string doc = r.Next(1000000, 9000000).ToString();

            _context.Owners.Add(new Owner
            {
                Document = doc,
                FirstName = "Exemplo",
                LastName = i.ToString(),
                Fixed_Phone = "211111111",
                Cell_Phone = "111111111",
                Address = "Lisboa"
            });
        }
    }
}
