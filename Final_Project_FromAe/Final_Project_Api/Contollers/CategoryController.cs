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
    public class CategoryController : ControllerBase
    {
        private readonly FromAeDbContext context;

        public CategoryController(FromAeDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await context.Categories.ToListAsync();
        }


        [HttpPost]
        public async Task AddCategory(Category category)
        {
            await context.Categories.AddAsync(category);
            context.SaveChanges();
        }

        [HttpPut("{id}")]
        public async Task UpdateCategory(int id, Category category)
        {
            var updateData = await context.Categories.FindAsync(id);
            updateData.Name = category.Name;
            updateData.Link = category.Link;
            updateData.Image = category.Image;
            context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public async Task DeleteCategory(int id)
        {
            var deleteCategory = await context.Categories.FindAsync(id);
            context.Categories.Remove(deleteCategory);
            context.SaveChanges();
        }
    }
}