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
    public class RatingController : ControllerBase
    {
        private readonly FromAeDbContext context;

        public RatingController(FromAeDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IEnumerable<Rating>> GetAllRating()
        {
            return await context.Ratings.ToListAsync();
        }


        [HttpPost]
        public async Task AddRating(Rating rating)
        {
            await context.Ratings.AddAsync(rating);
            context.SaveChanges();
        }

        [HttpPut("{id}")]
        public async Task UpdateRating(int id, Rating rating)
        {
            var updateData = await context.Ratings.FindAsync(id);
            updateData.Star = rating.Star;
            context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public async Task DeleteRating(int id)
        {
            var deleteRating = await context.Ratings.FindAsync(id);
            context.Ratings.Remove(deleteRating);
            context.SaveChanges();
        }
    }
}