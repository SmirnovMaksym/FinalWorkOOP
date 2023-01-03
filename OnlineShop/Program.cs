using OnlineShop.EF;
using OnlineShop.Menu;
using OnlineShop.Models;
using OnlineShop.Repositories;
using System;

namespace OnlineShop
{
    public class Program
    {
        static void Main(string[] args)
        {
            var db = new ShopContext();
            var menu = new ConsoleMenu(new UnitOfWork(db), new ShopCart());
            menu.Login();
        }
    }
}
