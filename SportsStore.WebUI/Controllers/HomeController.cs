using Microsoft.AspNetCore.Mvc;
using SportsStore.WebUI.Models;
using System.Diagnostics;
using SportsStore.Domain;
namespace SportsStore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository _repository;
        public int PageSize = 4;
        public HomeController(IProductRepository repo)
        {
            _repository = repo;
        }

        public ViewResult Index(string? category ,int Productpage = 1) {

            return View(new ProductListViewModel
            {
                Products = _repository.Products
                .Where(p => category == null || p.Category == category )
                .OrderBy(p => p.Category)
                .Skip((Productpage - 1) * PageSize)
                .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = Productpage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? _repository.Products.Count() : _repository.Products.Where(p => p.Category == category).Count()
                }
            });
        }


        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
