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
    }
}
