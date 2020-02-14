using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project_Api.Data
{
    public class ProductProperty
    {
      
        public string Value { get; set; }

        public Product Product { get; set; }
        public Property Property { get; set; }

        public int ProductId { get; set; }
        public int PropertyId { get; set; }

       
    }
}
