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
    public class PropertyController : ControllerBase
    {
        private readonly FromAeDbContext context;

        public PropertyController(FromAeDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IEnumerable<Property>> GetAllProperty()
        {
            return await context.Properties.ToListAsync();
        }


        [HttpPost]
        public async Task AddProperty(Property property)
        {
            await context.Properties.AddAsync(property);
            context.SaveChanges();
        }

        [HttpPut("{id}")]
        public async Task UpdateProperty(int id, Property property)
        {
            var updateData = await context.Properties.FindAsync(id);
            updateData.Name = property.Name;
            context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public async Task DeleteProperty(int id)
        {
            var deleteProperty = await context.Properties.FindAsync(id);
            context.Properties.Remove(deleteProperty);
            context.SaveChanges();
        }
    }
}