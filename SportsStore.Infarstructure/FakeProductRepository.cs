//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using SportsStore.Domain;
//namespace SportsStore.Infarstructure
//{
//    public class FakeProductRepository : IProductRepository
//    {
//        public IQueryable<Product> Products => new List<Product>
//        {
//            new Product { ProductId = 1, Name = "Football", Description = "A football", Price = 25, Category = "Soccer" ,ImgUrl = "/images/connor-coyne-OgqWLzWRSaI-unsplash.jpg"},
            
//            new Product { ProductId = 2, Name = "Surf board", Description = "A surf board", Price = 179, Category = "Watersports" , ImgUrl = "/images/gentrit-sylejmani-JjUyjE-oEbM-unsplash.jpg" },
            
//            new Product { ProductId = 3, Name = "Running shoes", Description = "A pair of running shoes", Price = 95, Category = "Running" , ImgUrl = "/images/sandro-schuh-HgwY_YQ1m0w-unsplash.jpg"},
            
//            new Product { ProductId = 4, Name = "Basketball", Description = "An official size basketball", Price = 35, Category = "Soccer", ImgUrl = "/images/basketball.jpg" },

//            new Product { ProductId = 5, Name = "Goalkeeper Gloves", Description = "Professional goalkeeper gloves", Price = 45, Category = "Soccer", ImgUrl = "/images/goalkeeper-gloves.jpg" },

//            new Product { ProductId = 6, Name = "Soccer Boots", Description = "Lightweight soccer boots", Price = 120, Category = "Soccer", ImgUrl = "/images/soccer-boots.jpg" },

//            new Product { ProductId = 7, Name = "Swimming Goggles", Description = "Anti-fog swimming goggles", Price = 22, Category = "Watersports", ImgUrl = "/images/swimming-goggles.jpg" },

//            new Product { ProductId = 8, Name = "Life Jacket", Description = "Comfortable life jacket", Price = 65, Category = "Watersports", ImgUrl = "/images/life-jacket.jpg" },

//            new Product { ProductId = 9, Name = "Kayak Paddle", Description = "Lightweight kayak paddle", Price = 89, Category = "Watersports", ImgUrl = "/images/kayak-paddle.jpg" },

//            new Product { ProductId = 10, Name = "Running Shorts", Description = "Breathable running shorts", Price = 30, Category = "Running", ImgUrl = "/images/running-shorts.jpg" },

//            new Product { ProductId = 11, Name = "Sports Watch", Description = "GPS running watch", Price = 199, Category = "Running", ImgUrl = "/images/sports-watch.jpg" },

//            new Product { ProductId = 12, Name = "Water Bottle", Description = "Insulated sports water bottle", Price = 18, Category = "Running", ImgUrl = "/images/water-bottle.jpg" },

//            new Product { ProductId = 13, Name = "Running Socks", Description = "Moisture-wicking running socks", Price = 15, Category = "Running", ImgUrl = "/images/running-socks.jpg" },


//        }.AsQueryable();
//    }
//}
