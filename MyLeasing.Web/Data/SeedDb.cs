using Microsoft.AspNetCore.Identity;
using MyLeasing.Web.Data.Entity;
using MyLeasing.Web.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private Random r;

        public SeedDb(DataContext context, IUserHelper userhelper)
        {
           _context = context;
            _userHelper = userhelper;
            r = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            var user = await _userHelper.GetUserByEmailAsync("bff3rreira03@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    Document = "000000000",
                    FirstName = "Bruno",
                    LastName = "Ferreira",
                    Email = "bff3rreira03@gmail.com",
                    UserName = "bff3rreira03@gmail.com",
                };

                var result = await _userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in the seeder");
                }
            }

            if (!_context.Owners.Any())
            {
                for (int i = 0; i < 10; i++)
                {
                    seedOwners(i, user);
                }
                await _context.SaveChangesAsync();
            }
        }

        private void seedOwners(int i, User User)
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
                Address = "Lisboa",
                user = User
            });
        }
    }
}
