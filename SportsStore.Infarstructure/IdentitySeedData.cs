using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.Domain;
using SportsStore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Infarstructure
{
    public static class IdentitySeedData
    {
        private const string adminUser = "Admin@gmail.com";
        private const string adminPassword = "SecretPassword123$";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            AppIdentityDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<AppIdentityDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            UserManager<SportsStore.Domain.AppUser> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<UserManager<SportsStore.Domain.AppUser>>();

            AppUser? user = await userManager.FindByNameAsync(adminUser);
            if (user == null)
            {
                user = new AppUser { UserName = adminUser };
                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}
