using OnlineShop.EF;
using OnlineShop.Models;
using System.Linq;

namespace OnlineShop.Initializer
{
    public static class ProductInitializer
    {
        public static void ProductInitialize(ShopContext context)
        {
            if (context.Products.ToList().Count != 0)
            {
                return;
            }
            context.Products.Add(new Product("Sausages", 100));
            context.Products.Add(new Product("Cheese", 150));
            context.Products.Add(new Product("Milk", 130));
            context.Products.Add(new Product("Bottle of water", 50));
            context.Products.Add(new Product("Jam", 85));
            context.Products.Add(new Product("Tea", 70));
        }
    }
}
