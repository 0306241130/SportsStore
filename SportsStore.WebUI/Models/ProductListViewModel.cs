using SportsStore.Domain;
using System.Collections;

namespace SportsStore.WebUI.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; } =  Enumerable.Empty<Product>();

        public PagingInfo PagingInfo { get; set; } = new ();
    }
}
