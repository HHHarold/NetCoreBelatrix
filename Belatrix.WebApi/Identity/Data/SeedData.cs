using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Belatrix.WebApi.Identity.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                var user = new ApplicationUser
                {
                    Email = "test@bela.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "hhh"
                };

                userManager.CreateAsync(user, "Welcome123!");
            }

        }
    }
}
