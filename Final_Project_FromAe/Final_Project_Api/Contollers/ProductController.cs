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
    public class ProductController : ControllerBase
    {
        private readonly FromAeDbContext context;

        public ProductController(FromAeDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await context.Products.ToListAsync();
        }


        [HttpPost]
        public async Task AddProduct(Product product)
        {
            await context.Products.AddAsync(product);
            context.SaveChanges();
        }

        [HttpPut("{id}")]
        public async Task UpdateProduct(int id, Product product)
        {
            var updateData = await context.Products.FindAsync(id);
            updateData.Name = product.Name;
            updateData.Price = product.Price;
            updateData.Discount = product.Discount;
            updateData.SalePrice = product.SalePrice;
            context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public async Task DeleteProduct(int id)
        {
            var deleteProduct = await context.Products.FindAsync(id);
            context.Products.Remove(deleteProduct);
            context.SaveChanges();
        }
    }
}