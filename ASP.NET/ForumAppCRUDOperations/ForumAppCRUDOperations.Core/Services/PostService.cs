using ForumAppCRUDOperations.Core.Contracts;
using ForumAppCRUDOperations.Core.Data;
using ForumAppCRUDOperations.Core.Data.Models;
using ForumAppCRUDOperations.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumAppCRUDOperations.Core.Services
{
    public class PostService : IPostService
    {
        private readonly FormAppDbContext context;

        public PostService(FormAppDbContext _context)
        {
            this.context = _context;
        }

        public async Task AddPost(AddPostViewModel model)
        {
            var post = new Post
            {
                Title = model.Title,
                Content = model.Content
            };

            await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostViewModel>> GetAllPosts()
        {
            var posts = await context.Posts
                .Select(p => new PostViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content
                })
                .ToListAsync();

            return posts;
        }
    }
}
