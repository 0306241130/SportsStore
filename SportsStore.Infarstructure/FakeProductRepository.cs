using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain;
namespace SportsStore.Infarstructure
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product { ProductID = 1, name = "Football", Description = "A football", Price = 25, Category = "Soccer" ,ImageUrl = "/images/connor-coyne-OgqWLzWRSaI-unsplash.jpg"},
            
            new Product { ProductID = 2, name = "Surf board", Description = "A surf board", Price = 179, Category = "Watersports" , ImageUrl = "/images/gentrit-sylejmani-JjUyjE-oEbM-unsplash.jpg" },
            
            new Product { ProductID = 3, name = "Running shoes", Description = "A pair of running shoes", Price = 95, Category = "Running" , ImageUrl = "/images/sandro-schuh-HgwY_YQ1m0w-unsplash.jpg"},
            
            new Product { ProductID = 4, name = "Basketball", Description = "An official size basketball", Price = 35, Category = "Soccer", ImageUrl = "/images/basketball.jpg" },

            new Product { ProductID = 5, name = "Goalkeeper Gloves", Description = "Professional goalkeeper gloves", Price = 45, Category = "Soccer", ImageUrl = "/images/goalkeeper-gloves.jpg" },

            new Product { ProductID = 6, name = "Soccer Boots", Description = "Lightweight soccer boots", Price = 120, Category = "Soccer", ImageUrl = "/images/soccer-boots.jpg" },

            new Product { ProductID = 7, name = "Swimming Goggles", Description = "Anti-fog swimming goggles", Price = 22, Category = "Watersports", ImageUrl = "/images/swimming-goggles.jpg" },

            new Product { ProductID = 8, name = "Life Jacket", Description = "Comfortable life jacket", Price = 65, Category = "Watersports", ImageUrl = "/images/life-jacket.jpg" },

            new Product { ProductID = 9, name = "Kayak Paddle", Description = "Lightweight kayak paddle", Price = 89, Category = "Watersports", ImageUrl = "/images/kayak-paddle.jpg" },

            new Product { ProductID = 10, name = "Running Shorts", Description = "Breathable running shorts", Price = 30, Category = "Running", ImageUrl = "/images/running-shorts.jpg" },

            new Product { ProductID = 11, name = "Sports Watch", Description = "GPS running watch", Price = 199, Category = "Running", ImageUrl = "/images/sports-watch.jpg" },

            new Product { ProductID = 12, name = "Water Bottle", Description = "Insulated sports water bottle", Price = 18, Category = "Running", ImageUrl = "/images/water-bottle.jpg" },

            new Product { ProductID = 13, name = "Running Socks", Description = "Moisture-wicking running socks", Price = 15, Category = "Running", ImageUrl = "/images/running-socks.jpg" },


        }.AsQueryable();
    }
}
