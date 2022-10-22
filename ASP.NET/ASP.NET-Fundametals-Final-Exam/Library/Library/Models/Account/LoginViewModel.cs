namespace Library.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    using static Library.Common.DataConstants.ApplicationUser;
    public class LoginViewModel
	{
        [Required]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
        public string UserName { get; set; }

        [Required]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
        public string Password { get; set; }
    }
}
