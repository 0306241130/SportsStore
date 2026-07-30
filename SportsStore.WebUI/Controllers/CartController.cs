using Microsoft.AspNetCore.Mvc;
using SportsStore.Domain;
using SportsStore.WebUI.Models;


namespace SportsStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository _repository;
        private Cart cartService;
        public CartController (IProductRepository repository , Cart cart)
        {
            _repository = repository;
            cartService = cart;
        }

        //Action de xem chi tiet gio hang
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                cart = cartService,
                returnUrl = returnUrl ?? "/"
            });
        }

        //Action de them san pham vao gio
        public RedirectToActionResult AddToCart(int productID, string returnUrl) { 
            Product? product = _repository.Products.FirstOrDefault(p => p.ProductID == productID);

            if(product != null)
            {
                cartService.AddItem(product, 1);
            }

            return RedirectToAction("Index", new {returnUrl});
        }

        //Action de xoa san pham khoi gio
        public RedirectToActionResult RemoveFormCart(int productID ,string returnUrl)
        {
            Product? product = _repository.Products
                .FirstOrDefault(p => p.ProductID ==productID);

            if (product != null) { 
                cartService.RemoveItem(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }  
    }
}
