using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_API.Data
{
    public class DatabaseInitializer
    {
        public static void Seed(IServiceScope serviceScope)
        {
            using (var context = serviceScope.ServiceProvider.GetRequiredService<MyCommerceDbContext>())
            {
                var configuration = serviceScope.ServiceProvider.GetRequiredService<IConfiguration>();
                var applicationUser = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                if (!applicationUser.Users.Any())
                {
                    ApplicationUser user = new ApplicationUser()
                    {
                        FirstName = configuration["User:FirstName"],
                        LastName = configuration["User:LastName"],
                        UserName = configuration["User:Username"],
                        Email = configuration["User:Email"],

                    };
                    applicationUser.CreateAsync(user, configuration["User:Password"]).GetAwaiter().GetResult();
                }

                /////////////////////////////////////////////////////////////////////////////////////////////////////////

                var identityRole = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

                if (!identityRole.Roles.Any())
                {
                    string[] UserRoles = configuration["Roles"].Split(",");

                    foreach (var item in UserRoles)
                    {
                        IdentityRole<int> role = new IdentityRole<int>
                        {
                            Name = item
                        };
                        identityRole.CreateAsync(role).GetAwaiter().GetResult();
                    }
                }

            }
        }
    }
}
