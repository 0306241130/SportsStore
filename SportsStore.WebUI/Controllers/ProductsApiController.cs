using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Domain;

namespace SportsStore.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsApiController : ControllerBase
    {
        private readonly IProductRepository _repository;
        public ProductsApiController(IProductRepository repository)
        {
            _repository = repository;
        }
        [HttpGet] // Xử lý request GET /api/products
        public IQueryable<Product> GetProducts()
        {
            return _repository.Products;
        }
    }
}
