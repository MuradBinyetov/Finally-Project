using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project_MVC.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }

       // public ICollection<SubMenu> SubMenus { get; set; }
    }
}
