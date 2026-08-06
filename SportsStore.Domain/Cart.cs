using System.ComponentModel.Design;

namespace SportsStore.Domain
{
    public class Cart
    {
     

        //Danh sach cac mat hang trong gio
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        //Them mot san pham vao gio hoac tang so luong neu da ton tai

        public virtual void AddItem(Product product, int quantity) { 
            CartLine? line = Lines.Where(p => p.product.ProductId == product.ProductId).FirstOrDefault();

            if (line == null) {
                Lines.Add(new CartLine
                {
                    product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveItem(Product product) {
            Lines.RemoveAll(l => l.product.ProductId == product.ProductId);
        }

        public decimal ComputeTotalValue()
        {
            return Lines.Sum(l => l.product.Price * l.Quantity);
        }

        public virtual void Clear()
        {
            Lines.Clear();
        }

    }

    //Lop dai dien cho mot san pham trong gio hang (mot san pham va so luong cua no)    
    public class CartLine
    {
        public int CartLineId { get; set; }
        public Product product { get; set; } = new Product();

        public int Quantity { get; set; }
    }
}
