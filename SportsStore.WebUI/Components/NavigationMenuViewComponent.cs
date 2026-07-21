using Microsoft.AspNetCore.Mvc;
using SportsStore.Domain;

namespace SportsStore.WebUI.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly IProductRepository _repository;
        public NavigationMenuViewComponent(IProductRepository repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            return View(_repository.Products);
        }
    }
}
