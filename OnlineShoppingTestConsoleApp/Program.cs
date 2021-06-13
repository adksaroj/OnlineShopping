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

            }

            Console.WriteLine("Completed...");
            Console.ReadKey();
        }
    }
}
