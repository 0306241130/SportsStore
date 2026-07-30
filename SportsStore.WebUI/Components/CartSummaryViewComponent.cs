using Microsoft.AspNetCore.Mvc;
using SportsStore.Domain;
using SportsStore.WebUI.Models;
namespace SportsStore.WebUI.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;

        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
