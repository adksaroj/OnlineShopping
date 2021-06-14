using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShoppingDataAccess;

namespace OnlineShoppingTestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Operation...");

            using (OnlineShoppingEntities dbContext = new OnlineShoppingEntities())
            {
                //List<Products> products = new List<Products>();

                //var p = dbContext.Products.Where(x => (x.Id == 8003 || x.Id == 8002)).ToList();
                //products.AddRange(p);

                //Cart cart = new Cart();
                //cart.UserId = 12002;
                //cart.Products = products;

                //dbContext.Cart.Add(cart);
                //dbContext.SaveChanges();

                var items = dbContext.Cart.Where(x => x.UserId == 12002).ToList();
                var prods = items.SelectMany(y => y.Products);
                foreach (var item in prods)
                {
                    Console.WriteLine(item.ProductName);
                }
            }

            Console.WriteLine("Completed...");
            Console.ReadKey();
        }
    }
}
