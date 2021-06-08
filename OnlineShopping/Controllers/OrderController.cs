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
        [ChildActionOnly]
        public ActionResult Create()
        {
            return RedirectToAction("myorders");
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
                                //Math.Round(productView.Cost, 2);
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

                        ordersListVM.Add(orderVM);

                    }

                    return View(ordersListVM);

                }
            }

            return View();
        }
    }
}