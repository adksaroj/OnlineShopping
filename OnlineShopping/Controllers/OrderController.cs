using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoppingDataAccess;
using OnlineShopping.Utilities;
using OnlineShopping.Models;

namespace OnlineShopping.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        //[ChildActionOnly]
        public ActionResult Create(CheckoutVM checkout)
        {
            if (ModelState.IsValid)
            {
                using (OnlineShoppingEntities dbContext = new OnlineShoppingEntities())
                {
                    if (checkout.Cart != null)
                    {
                        var order = new Orders();
                        order.Id = UserUtility.GetUserByUserId(User.Identity.Name).Id;
                        order.Quantity = 1;
                        order.Date = DateTime.Now;
                        order.OrderStatus = "Ordered";
                        order.Price = checkout.OrderTotal;

                        dbContext.Orders.Add(order);
                        dbContext.SaveChanges();
                    }
                }
                return RedirectToAction("myorders");

            }


            return RedirectToAction("checkout");
        }

        public ActionResult MyOrders()
        {
            using (OnlineShoppingEntities dbContext = new OnlineShoppingEntities())
            {
                var loggedInUserId = UserUtility.GetUserByUserId(User.Identity.Name).Id;
                var orders = dbContext.Orders.Where(o => o.ClientId == loggedInUserId).ToList();
                if (orders.Count > 0)
                {
                    List<OrderViewModel> ordersListVM = new List<OrderViewModel>();

                    foreach (var order in orders)
                    {
                        OrderViewModel orderVM = new OrderViewModel();
                        List<ProductViewModel> productListVM = new List<ProductViewModel>();

                        if (order.Products != null)
                        {
                            foreach (var product in order.Products)
                            {
                                ProductViewModel productView = new ProductViewModel();
                                productView.Id = product.Id;
                                productView.ProductId = product.ProductId;
                                productView.ProductName = product.ProductName;
                                productView.Category = product.Category;
                                productView.Description = product.Description;
                                productView.Cost = (decimal)product.Cost;
                                productView.Quantity = (int)order.Quantity;
                                productListVM.Add(productView);
                            }
                        }

                        //pvm.Id = order.Products.Id;
                        //pvm.ProductId = order.Products.ProductId;
                        //pvm.ProductName = order.Products.ProductName;
                        //pvm.Category = order.Products.Category;
                        //pvm.Description = order.Products.Description;
                        //pvm.Quantity = (int)order.Quantity;

                        List<ProductViewModel> productsForOrder = new List<ProductViewModel>();
                        productsForOrder.AddRange(productListVM);

                        orderVM.OrderId = order.Id;
                        orderVM.Products = productsForOrder;
                        orderVM.OrderTotal = (decimal)order.Price;
                        orderVM.PaymentMode = "Cash on Delivery";
                        orderVM.OrderAddress = order.Users.Address;
                        orderVM.Products = productsForOrder;
                        orderVM.OrderStatus = order.OrderStatus;

                        ordersListVM.Add(orderVM);

                    }

                    return View(ordersListVM);

                }
            }

            return View();
        }
    }
}