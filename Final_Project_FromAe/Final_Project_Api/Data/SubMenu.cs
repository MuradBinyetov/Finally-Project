using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project_Api.Data
{
    public class SubMenu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }


        public Menu Menu { get; set; }
        public int MenuId { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
