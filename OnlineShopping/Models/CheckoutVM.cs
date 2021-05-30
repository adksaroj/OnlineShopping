using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using OnlineShoppingDataAccess;

namespace OnlineShopping.Models
{
    public class CheckoutVM
    {
        [Required]
        public List<CartViewModel> Cart { get; set; }

        public Users User { get; set; }

        [Required]
        [Display(Name = "Shipping Address")]
        public string ShippingAddress { get; set; }

        [Required]
        [Display(Name = "Payment Method")]
        public string PaymentMethod { get; set; }

        [Required]
        [Display(Name = "Order Total")]
        public decimal OrderTotal { get; set; }
    }
}