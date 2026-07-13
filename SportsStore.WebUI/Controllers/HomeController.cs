using Microsoft.AspNetCore.Mvc;
using SportsStore.WebUI.Models;
using System.Diagnostics;
using SportsStore.Domain;
namespace SportsStore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository _repository;

        public HomeController(IProductRepository repo)
        {
            _repository = repo;
        }

        public ViewResult Index() => View(_repository.Products);

        public ViewResult Index1() => View(_repository.Products);

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
