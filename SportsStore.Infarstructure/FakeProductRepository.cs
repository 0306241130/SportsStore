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
           
        }.AsQueryable();
    }
}
