namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Library.Common.DataConstants.Category;

    public class Category
    {
        public Category()
        {
            this.Books = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}