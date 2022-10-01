using System.ComponentModel.DataAnnotations;
using static ForumAppCRUDOperations.Core.Data.DataConstants.Post;

namespace ForumAppCRUDOperations.Core.Models
{
    public class AddPostViewModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; }
    }
}
