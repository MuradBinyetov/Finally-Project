using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project_Api.Data
{
    public class Rating
    {
        public int Id { get; set; }

        public byte Star { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
