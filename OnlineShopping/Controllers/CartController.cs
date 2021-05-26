using OnlineShopping.Models;
using OnlineShoppingDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopping.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            var cartItemsForUser = GetCartItemForUser();
            return View(cartItemsForUser);
        }

        //[HttpPost]
        public ActionResult AddToCart(int id)
        {
            var cartData = GetCartItemForUser();

            var dbProd = new Products();

            var newCart = new CartViewModel();
            newCart.user = new Users() { Email = User.Identity.Name };

            using(OnlineShoppingEntities dbContext = new OnlineShoppingEntities())
            {
                dbProd = dbContext.Products.Where(p => p.Id == id).FirstOrDefault();
            }

            //if (cartData != null && product != null)
            //{
            //    dbProd.Id = product.Id;
            //    dbProd.ProductId = product.ProductId;
            //    dbProd.ProductName = product.ProductName;
            //    dbProd.Category = product.Category;
            //    dbProd.Cost = product.Cost;
            //    dbProd.Description = product.Description;
            //    dbProd.ImageName = product.Image.FileName;
            //}
            if (dbProd.Id == 0 && cartData == null)
            {

            }
            //return Json("Could not add product");
            else if (dbProd.Id != 0 && cartData != null)
            {
                if(IsProductAlreadyOnCart(dbProd))
                {
                    //find the product existing on cart and increment its quantity
                    cartData.Find(cvm => cvm.product.Id == dbProd.Id).Quantity++;
                }
                else
                {
                    newCart.product = dbProd;
                    cartData.Add(newCart);
                }
                Session["cart"] = cartData;
            }
            else if (dbProd.Id != 0 && cartData == null)
            {
                var cartList = new List<CartViewModel>();
                newCart.product = dbProd;

                if (IsProductAlreadyOnCart(dbProd))
                {
                    newCart.Quantity++;
                }

                cartList.Add(newCart);
                Session["cart"] = cartList;
            }

            return RedirectToAction("Index");
        }

        protected List<CartViewModel> GetCartItemForUser()
        {
            var cartData = Session["cart"];

            var allCart = (List<CartViewModel>)cartData;

            var cartItemsForUser = allCart?.Where(cvm => cvm.user.Email == User.Identity.Name).ToList();

            return cartItemsForUser;
        }

        protected bool IsProductAlreadyOnCart(Products product)
        {
            var userCart = GetCartItemForUser();

            var productFromCart = userCart?.Where(cvm => cvm.product.Id == product.Id).FirstOrDefault();

            if(productFromCart != null)
            {
                return true;
            }

            return false;
        }
    }
}