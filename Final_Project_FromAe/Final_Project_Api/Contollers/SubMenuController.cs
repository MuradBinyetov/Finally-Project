using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Project_Api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Api.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubMenuController : ControllerBase
    {
        private readonly FromAeDbContext context;

        public SubMenuController(FromAeDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IEnumerable<SubMenu>> GetAllSubMenu()
        {
            return await context.SubMenus.ToListAsync();
        }


        [HttpPost]
        public async Task AddSubMenu(SubMenu subMenu)
        {
            await context.SubMenus.AddAsync(subMenu);
            context.SaveChanges();
        }

        [HttpPut("{id}")]
        public async Task UpdateSubMenu(int id, SubMenu subMenu)
        {
            var updateData = await context.SubMenus.FindAsync(id);
            updateData.Name = subMenu.Name;
            updateData.Link = subMenu.Link;
            context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public async Task DeleteSubMenu(int id)
        {
            var deleteSubMenu = await context.SubMenus.FindAsync(id);
            context.SubMenus.Remove(deleteSubMenu);
            context.SaveChanges();
        }
    }
}