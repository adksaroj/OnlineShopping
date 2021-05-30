using OnlineShopping.Models;
using OnlineShoppingDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopping.Utilities
{
    public static class CartUtility
    {
        public static List<CartViewModel> GetCartItemForUser(string emailId)
        {
            var cartData = HttpContext.Current.Session["cart"];

            var allCart = (List<CartViewModel>)cartData;

            var cartItemsForUser = allCart?.Where(cvm => cvm.user.Email == emailId).ToList();

            return cartItemsForUser;
        }

        public static bool IsProductAlreadyOnCart(Products product, string emailId)
        {
            var userCart = GetCartItemForUser(emailId);

            var productFromCart = userCart?.Where(cvm => cvm.product.Id == product.Id).FirstOrDefault();

            if (productFromCart != null)
            {
                return true;
            }

            return false;
        }
    }
}