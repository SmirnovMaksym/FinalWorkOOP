using System.Collections.Generic;

namespace OnlineShop.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Balance { get; set; }

        public List<Product> BoughtProducts { get; set; }

        public User(string name)
        {
            Name = name;
            BoughtProducts = new List<Product>();
        }

        public override string ToString()
        {
            string res = $"Id: {Id}. Name: {Name}.\nBought products:";
            foreach (var item in BoughtProducts)
            {
                res += item;
            }
            return res;
        }
    }
}
