using OnlineShop.Interfaces;
using OnlineShop.Models;
using System;
using System.Threading.Tasks;

namespace OnlineShop.Menu
{
    public class ConsoleMenu
    {
        private ShopCart cart;
        private User _currentUser { get; set; }
        private IUnitOfWork _unitOfWork { get; set; }

        public ConsoleMenu(IUnitOfWork unitOfWork, ShopCart cart)
        {
            _unitOfWork = unitOfWork;
            this.cart = cart;
        }

        public async Task Login()
        {
            string username;
            Console.WriteLine("Enter username: ");
            username = Console.ReadLine();
            if(!await _unitOfWork.UserRepository.IfExistAsync(username))
            {
                await _unitOfWork.UserRepository.AddAsync(new User(username));
            }
            _currentUser = await _unitOfWork.UserRepository.GetUserAsync(username);
            await ShowMenu();
        }

        private async Task ShowMenu()
        {
            while(true)
            {
                try
                {
                    int choosen;
                    Console.WriteLine($"Enter 1 to check product list\nEnter 2 to add product to shop cart\nEnter 3 to get shop cart\nEtner 4 to buy products from shop cart\nEnter 5 to check all bought product by user: '{_currentUser.Name}'\nEnter 6 to add money to your balance");
                    Console.Write("Your choice: ");
                    choosen = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    switch (choosen)
                    {
                        case 1:
                            {
                                var productList = await _unitOfWork.ProductRepository.GetAllAsync();
                                foreach (var product in productList)
                                {
                                    Console.WriteLine(product);
                                }
                                break;
                            }
                        case 2:
                            {
                                int id;
                                Console.WriteLine("Enter product`s id to add it to shop cart: ");
                                id = Convert.ToInt32(Console.ReadLine());
                                cart.Add(await _unitOfWork.ProductRepository.Get(id));
                                Console.WriteLine("Added!");
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("All Shop card: ");
                                foreach (var prod in cart.Products)
                                {
                                    Console.WriteLine(prod);
                                }
                                break;
                            }
                        case 4:
                            {
                                decimal sum = 0;
                                foreach (var prod in cart.Products)
                                {
                                    sum += prod.Price;
                                }
                                if (sum > _currentUser.Balance)
                                {
                                    throw new Exception("No money for buy");
                                }
                                else
                                {
                                    foreach (var item in cart.Products)
                                    {
                                        await _unitOfWork.UserRepository.AddProductAsync(item.Id, _currentUser.Id);
                                    }
                                    _currentUser.Balance -= sum;
                                    cart.Clear();
                                    Console.WriteLine($"Bought! Your balance = {_currentUser.Balance}");
                                }
                                break;
                            }
                        case 5:
                            {
                                Console.WriteLine("All bought products:");
                                var list = await _unitOfWork.UserRepository.GetBoughtProducts(_currentUser.Id);
                                foreach (var item in list)
                                {
                                    Console.WriteLine(item);
                                }
                                break;
                            }
                        case 6:
                            {
                                decimal money;
                                Console.WriteLine("Enter amount of money to add it: ");
                                money = Convert.ToDecimal(Console.ReadLine());
                                _currentUser.Balance += money;
                                break;
                            }
                    }
                    Console.WriteLine("\n\n\n");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
