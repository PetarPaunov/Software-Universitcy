using System.ComponentModel.DataAnnotations;
using Watchlist.Data.Models;

namespace Watchlist.Models
{
    public class MovieViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Director { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "10.00")]
        public decimal Rating { get; set; }

        [Required]
        public int GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();
    }
}
