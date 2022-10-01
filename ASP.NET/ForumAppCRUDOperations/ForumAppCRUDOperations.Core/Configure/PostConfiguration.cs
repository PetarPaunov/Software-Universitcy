using ForumAppCRUDOperations.Core.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForumAppCRUDOperations.Core.Configure
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            List<Post> posts = GetPosts();

            builder.HasData(posts);
        }

        private List<Post> GetPosts()
        {
            return new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Title = "My First Post",
                    Content = "This is my first post"
                },
                new Post
                {
                    Id = 2,
                    Title = "My Second Post",
                    Content = "This is my second post"
                },
                new Post
                {
                    Id = 3,
                    Title = "My Third Post",
                    Content = "This is my third post"
                }
            };
        }
    }
}
