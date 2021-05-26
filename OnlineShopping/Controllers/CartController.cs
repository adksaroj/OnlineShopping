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
            var cartData = Session["cart"];

            var cartList = (List<Products>)cartData;

            return View(cartData);
        }

        //[HttpPost]
        public ActionResult AddToCart(int id)
        {
            var cartData = (List<Products>)Session["cart"];
            var dbProd = new Products();

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
                cartData.Add(dbProd);
            else if (dbProd.Id != 0 && cartData == null)
            {
                var list = new List<Products>();
                list.Add(dbProd);
                Session["cart"] = list;
            }

            return RedirectToAction("Index");
        }
    }
}