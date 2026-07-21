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

        public ViewResult Index(int page = 1) {
            var repo = _repository.Products.Skip((page - 1) * 2).Take(2);
            ViewBag.TotalPages = (int)Math.Ceiling((double)_repository.Products.Count() / 2);
            return View(repo);
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
