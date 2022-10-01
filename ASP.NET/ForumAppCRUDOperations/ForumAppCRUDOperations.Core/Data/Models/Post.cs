using System.ComponentModel.DataAnnotations;
using static ForumAppCRUDOperations.Core.Data.DataConstants.Post;

namespace ForumAppCRUDOperations.Core.Data.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; }

        public bool IsDeleted { get; set; }
    }
}

//•	Id – an unique integer, primary key
//•	Title – a string with min length 10 and max length 50 (required)
//•	Content – a string with min length 30 and max length 1500 (required)

