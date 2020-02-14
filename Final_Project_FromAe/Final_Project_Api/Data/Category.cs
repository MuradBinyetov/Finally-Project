using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project_Api.Data
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }

        public SubMenu SubMenu { get; set; }
        public int SubMenuId { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
