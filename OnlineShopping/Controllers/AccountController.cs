using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoppingDataAccess;
using OnlineShopping.Utilities;
using System.Web.Security;

namespace OnlineShopping.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            ViewBag.Error = "No Error";
            if(User.Identity.IsAuthenticated)
                return RedirectToAction("index", "home");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Password = Base64Utility.Base64Encode(model.Password);
                using (OnlineShoppingEntities dbContext = new OnlineShoppingEntities())
                {
                    var userDetails = dbContext.Users.Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();
                    if (userDetails == null)
                        ViewBag.Error = "Invalid Username or Password.";
                    else
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, false);
                        return RedirectToAction("index", "home");
                    }
                }

            }
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (OnlineShoppingEntities dbContext = new OnlineShoppingEntities())
                {
                    Users user = new Users();
                    user.Username = model.Username;
                    user.Password = Base64Utility.Base64Encode(model.Password);
                    user.Email = model.Email;
                    user.Role = model.Role;
                    user.Address = model.Address;

                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();

                    return RedirectToAction("login", "account");
                }

            }
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login", "account");
        }
    }
}