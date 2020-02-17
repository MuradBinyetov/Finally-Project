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
    public class MarkaController : ControllerBase
    {
        private readonly FromAeDbContext context;

        public MarkaController(FromAeDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IEnumerable<Marka>> GetAllMarka()
        {
            return await context.Markas.ToListAsync();
        }


        [HttpPost]
        public async Task AddMarka(Marka marka)
        {
            await context.Markas.AddAsync(marka);
            context.SaveChanges();
        }

        [HttpPut("{id}")]
        public async Task UpdateMarka(int id, Marka marka)
        {
            var updateData = await context.Markas.FindAsync(id);
            updateData.Name = marka.Name;
            context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public async Task DeleteMarka(int id)
        {
            var deleteMarka = await context.Markas.FindAsync(id);
            context.Markas.Remove(deleteMarka);
            context.SaveChanges();
        }
    }
}