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
    public class ModelController : ControllerBase
    {
        private readonly FromAeDbContext context;

        public ModelController(FromAeDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IEnumerable<Model>> GetAllModel()
        {
            return await context.Models.ToListAsync();
        }


        [HttpPost]
        public async Task AddModel(Model model)
        {
            await context.Models.AddAsync(model);
            context.SaveChanges();
        }

        [HttpPut("{id}")]
        public async Task UpdateModel(int id, Model model)
        {
            var updateData = await context.Models.FindAsync(id);
            updateData.Name = model.Name;
            context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public async Task DeleteModel(int id)
        {
            var deleteModel = await context.Models.FindAsync(id);
            context.Models.Remove(deleteModel);
            context.SaveChanges();
        }
    }
}