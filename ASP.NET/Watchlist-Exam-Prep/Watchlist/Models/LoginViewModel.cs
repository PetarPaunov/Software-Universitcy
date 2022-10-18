using System.ComponentModel.DataAnnotations;

namespace Watchlist.Models
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string UserName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Password { get; set; }

    }
}
