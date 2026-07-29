using SportsStore.Domain;

namespace SportsStore.WebUI.Models
{

    public class CartLine
    {
        public int CartLineID { get; set; }

        public Product Product { get; set; } = new();

        public int Quantity { get; set; }


    }
    public class Cart
    {
        public List<CartLine> Lines {  get; set; } = new List<CartLine> ();
        
        public virtual void AddItem(Product product , int quantity)
        {
            CartLine? Line = Lines.FirstOrDefault(p => p.Product.ProductID == product.ProductID);

            if (Line == null) {
                Lines.Add(new CartLine { Product = product , Quantity =quantity });
            }
            else
            {
                Line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Product product) => Lines.RemoveAll(l => l.Product.ProductID == product.ProductID);

        public decimal ComputeTotalValue() => Lines.Sum(e => e.Quantity * e.Product.Price);

        public virtual void Clear() => Lines.Clear();
    }
}
