using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int UnitsInStock { get; set; }
        public decimal SellPrice { get; set; }
        public int DiscountPercentage { get; set; }
        public int UnitsMax { get; set; }
    }
}
