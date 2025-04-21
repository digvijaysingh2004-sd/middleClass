using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiddelClass.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Badge { get; set; }
        public int Category { get; set; }
        public string CategoryName { get; set; }
        public string Size { get; set; }
        public string SizeName { get; set; }
        public int Material { get; set; }
        public string MaterialName { get; set; }
        public string Color { get; set; }
        public string ColorName { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountPrice { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string AllImages { get; set; }
        public string Cby { get; set; }
        public string Uby { get; set; }
        public int Status { get; set; }
        public DateTime? Cdate { get; set; }
        public DateTime? Udate { get; set; }
    }
}