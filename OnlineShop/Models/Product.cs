namespace OnlineShop.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"Id: {Id}. Name: {Name}. Price: {Price}";
        }
    }
}
