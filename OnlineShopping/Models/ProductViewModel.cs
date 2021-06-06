using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopping.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Product ID")]
        [Required(ErrorMessage = "Product ID is required")]
        [DataType(DataType.Text)]
        public string ProductId { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name is required")]
        [DataType(DataType.Text)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Cost is required")]
        [DataType(DataType.Text)]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [DataType(DataType.Text)]
        public string Category { get; set; }
        
        public HttpPostedFileBase Image { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }
    }
}