using OnlineShoppingDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopping.Utilities
{
    public class UserUtility
    {
        public static Users GetUserByUserId(string emailId)
        {
            using (OnlineShoppingEntities dbContext = new OnlineShoppingEntities())
            {
                var user = dbContext.Users.Where(u => u.Email == emailId).FirstOrDefault();
                return user;
            }
        }
    }
}