using Microsoft.AspNetCore.Mvc;
using SportsStore.Domain;

namespace SportsStore.WebUI.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        //private readonly IProductRepository _repository;
        //public NavigationMenuViewComponent(IProductRepository repository)
        //{
        //    _repository = repository;
        //}

        public IViewComponentResult Invoke()
        {
            var categories = new string[] { "WaterSports", "Soccer", "Chess" };
            return View(categories);
        }
    }
}
