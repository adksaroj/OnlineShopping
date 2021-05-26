using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShoppingDataAccess;

namespace OnlineShopping.Models
{
    public class CartViewModel
    {
        public Users user { get; set; }

        public Products product { get; set; }

        public int Quantity { get; set; }

        public CartViewModel()
        {
            Quantity = 1;
        }
    }
}