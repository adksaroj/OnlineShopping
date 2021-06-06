using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopping.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public decimal OrderTotal { get; set; }
        public string PaymentMode { get; set; }
        public string OrderAddress { get; set; }
    }
}