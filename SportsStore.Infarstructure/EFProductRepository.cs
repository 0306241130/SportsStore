using SportsStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Infarstructure
{
    public class EFProductRepository : IProductRepository
    {
        private ApplicationDBContext _context;

        public EFProductRepository(ApplicationDBContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<Product> Products => _context.Products;

        public void SaveProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                _context.Products.Add(product);
            }
            else
            {
                Product? dbEntry = _context.Products
                    .FirstOrDefault(p => p.ProductId == product.ProductId);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Price = product.Price;
                    dbEntry.Description = product.Description;
                    dbEntry.Category = product.Category;
                    dbEntry.ImgUrl = product.ImgUrl;
                }
            }
            _context.SaveChanges();
        }

        public Product? DeleteProduct(int productID)
        {
            Product? dbEntry = _context.Products.
                FirstOrDefault(p => p.ProductId == productID);

            if (dbEntry != null)
            {
                _context.Products.Remove(dbEntry);
                _context.SaveChanges();
            }

            return dbEntry;
        }
    }
}
