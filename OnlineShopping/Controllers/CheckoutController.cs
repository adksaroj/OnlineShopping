using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShopping.Models;
using OnlineShopping.Utilities;

namespace OnlineShopping.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        public ActionResult Index()
        {
            CheckoutVM checkOut = new CheckoutVM();

            checkOut.User = UserUtility.GetUserByUserId(User.Identity.Name);
            checkOut.Cart = CartUtility.GetCartItemForUser(checkOut.User.Email);
            checkOut.PaymentMethod = "Cash On Delivery";
            decimal orderTot = 0;

            if (checkOut.Cart != null && checkOut.User != null)
            {
                foreach (var item in checkOut.Cart)
                {
                    orderTot += item.product.Cost;
                }
                checkOut.OrderTotal = Math.Round(orderTot,2);

                checkOut.ShippingAddress = checkOut.User.Address;

                return View(checkOut);

            }

            return View();
        }
    }
}