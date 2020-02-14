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
    public class MenuController : ControllerBase
    {

        private readonly FromAeDbContext context;

        public MenuController(FromAeDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IEnumerable<Menu>> GetAllMenu()
        {
          return  await context.Menus.ToListAsync();
        }


        [HttpPost]
        public async Task AddMenu(Menu menu)
        {
            await context.Menus.AddAsync(menu);
             context.SaveChanges();
        }

        [HttpPut("{id}")]
        public async Task UpdateMenu(int id,Menu menu)
        {
           var updateData=await context.Menus.FindAsync(id);
            updateData.Name = menu.Name;
            updateData.Link = menu.Link;
            context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public async Task DeleteMenu(int id)
        {
            var deleteMenu=await context.Menus.FindAsync(id);
            context.Menus.Remove(deleteMenu);
            context.SaveChanges();
        }
    }
}