using SportsStore.Domain;

namespace SportsStore.WebUI.Models
{
    public class CartIndexViewModel
    {
        public required  Cart cart { get; set; }

        public string returnUrl { get; set; } = "/";
    }
}
