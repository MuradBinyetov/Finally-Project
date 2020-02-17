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
    public class CommentController : ControllerBase
    {
        private readonly FromAeDbContext context;

        public CommentController(FromAeDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IEnumerable<Comment>> GetAllComment()
        {
            return await context.Comments.ToListAsync();
        }


        [HttpPost]
        public async Task AddComment(Comment comment)
        {
            await context.Comments.AddAsync(comment);
            context.SaveChanges();
        }

        [HttpPut("{id}")]
        public async Task UpdateComment(int id, Comment comment)
        {
            var updateData = await context.Comments.FindAsync(id);
            updateData.UserName = comment.UserName;
            updateData.Description = comment.Description;
            context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public async Task DeleteComment(int id)
        {
            var deleteComment = await context.Comments.FindAsync(id);
            context.Comments.Remove(deleteComment);
            context.SaveChanges();
        }
    }
}