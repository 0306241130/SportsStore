using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Infarstructure
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDBContext context = app.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<ApplicationDBContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product { Name = "Football", Description = "A football", Price = 25, Category = "Soccer", ImgUrl = "/images/connor-coyne-OgqWLzWRSaI-unsplash.jpg" },

            new Product {  Name = "Surf board", Description = "A surf board", Price = 179, Category = "Watersports", ImgUrl = "/images/gentrit-sylejmani-JjUyjE-oEbM-unsplash.jpg" },

            new Product {  Name = "Running shoes", Description = "A pair of running shoes", Price = 95, Category = "Running", ImgUrl = "/images/sandro-schuh-HgwY_YQ1m0w-unsplash.jpg" },

            new Product {  Name = "Basketball", Description = "An official size basketball", Price = 35, Category = "Soccer", ImgUrl = "/images/basketball.jpg" },

            new Product {  Name = "Goalkeeper Gloves", Description = "Professional goalkeeper gloves", Price = 45, Category = "Soccer", ImgUrl = "/images/goalkeeper-gloves.jpg" },

            new Product {  Name = "Soccer Boots", Description = "Lightweight soccer boots", Price = 120, Category = "Soccer", ImgUrl = "/images/soccer-boots.jpg" },

            new Product {  Name = "Swimming Goggles", Description = "Anti-fog swimming goggles", Price = 22, Category = "Watersports", ImgUrl = "/images/swimming-goggles.jpg" },

            new Product {  Name = "Life Jacket", Description = "Comfortable life jacket", Price = 65, Category = "Watersports", ImgUrl = "/images/life-jacket.jpg" },

            new Product {  Name = "Kayak Paddle", Description = "Lightweight kayak paddle", Price = 89, Category = "Watersports", ImgUrl = "/images/kayak-paddle.jpg" },

            new Product {  Name = "Running Shorts", Description = "Breathable running shorts", Price = 30, Category = "Running", ImgUrl = "/images/running-shorts.jpg" },

            new Product {  Name = "Sports Watch", Description = "GPS running watch", Price = 199, Category = "Running", ImgUrl = "/images/sports-watch.jpg" },

            new Product {  Name = "Water Bottle", Description = "Insulated sports water bottle", Price = 18, Category = "Running", ImgUrl = "/images/water-bottle.jpg" },

            new Product {  Name = "Running Socks", Description = "Moisture-wicking running socks", Price = 15, Category = "Running", ImgUrl = "/images/running-socks.jpg" }
                );
                context.SaveChanges();
            }
        }
    }
}
