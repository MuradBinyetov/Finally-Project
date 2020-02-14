using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project_Api.Data
{
    public class ProductCategory
    {
       
        public Product Product { get; set; }
        public Category Category { get; set; }

        public int ProductId { get; set; }
        public int CategoryId { get; set; }
    }
}
