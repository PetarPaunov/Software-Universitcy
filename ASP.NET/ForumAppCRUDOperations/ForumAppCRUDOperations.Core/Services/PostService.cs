using ForumAppCRUDOperations.Core.Contracts;
using ForumAppCRUDOperations.Core.Data;
using ForumAppCRUDOperations.Core.Data.Models;
using ForumAppCRUDOperations.Core.Models;
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

        public async Task DeletePost(int id)
        {
            var post = await context.Posts.FindAsync(id);

            if (post != null)
            {
                post.IsDeleted = true;
                await context.SaveChangesAsync();
            }
        }

        public async Task EditPost(EditPostViewModel model)
        {
            var post = await context.Posts.FindAsync(model.Id);

            post.Title = model.Title;
            post.Content = model.Content;

            await context.SaveChangesAsync();
        }

        public async Task<EditPostViewModel> FindById(int id)
        {
            var post = await context.Posts
                .Where(p => p.Id == id)
                .Select(p => new EditPostViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content
                })
                .FirstOrDefaultAsync();

            if (post != null)
            {
               return post;
            }

            return null;
        }

        public async Task<IEnumerable<PostViewModel>> GetAllPosts()
        {
            var posts = await context.Posts
                .Where(p => p.IsDeleted == false)
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
