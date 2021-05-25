using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShopping.Models;
using OnlineShoppingDataAccess;

namespace OnlineShopping.Controllers
{
    [Authorize(Roles = "admin, user")]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            using (OnlineShoppingEntities dbContext = new OnlineShoppingEntities())
            {
                IEnumerable<Products> prods = dbContext.Products.ToList<Products>();
                return View(prods);
            }
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string fileName = "";

                    if (product.Image !=null && product.Image.ContentType.Contains("image"))
                    {
                        string path = Server.MapPath("~/static/products");
                        string imageName = product.ProductId + "." + product.Image.ContentType.Substring(6);
                        fileName = Path.GetFileName(imageName);

                        string fullPath = Path.Combine(path, fileName);

                        product.Image.SaveAs(fullPath);

                    }

                    using (OnlineShoppingEntities dbContext = new OnlineShoppingEntities())
                    {
                        Products prod = new Products();
                        prod.ProductId = product.ProductId;
                        prod.ProductName = product.ProductName;
                        prod.Cost = product.Cost;
                        prod.Category = product.Category;
                        prod.Description = product.Description;



                        prod.ImageName = fileName;

                        dbContext.Products.Add(prod);
                        dbContext.SaveChanges();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            using (OnlineShoppingEntities dbContext = new OnlineShoppingEntities())
            {
                Products prod = dbContext.Products.Where(p => p.Id == id).FirstOrDefault();
                return View(prod);
            }
        }
    }
}