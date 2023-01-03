using System.Collections.Generic;

namespace OnlineShop.Models
{
    public class ShopCart
    {
        public List<Product> Products { get; private set; }

        public ShopCart()
        {
            Products = new List<Product>();
        }

        public void Clear()
        {
            Products.Clear();
        }

        public void Add(Product product)
        {
            Products.Add(product);
        }
    }
}
