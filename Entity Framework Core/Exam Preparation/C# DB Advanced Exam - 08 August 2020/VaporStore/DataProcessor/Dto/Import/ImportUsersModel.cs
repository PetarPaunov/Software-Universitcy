using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUsersModel
    {
        [Required]
        [RegularExpression(@"[A-Z][a-z]+\s[A-Z][a-z]+")]
        public string FullName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Range(3, 103)]
        public int Age { get; set; }

        public CardInputModel[] Cards { get; set; }
    }

    //•	FullName – text, which has two words, consisting of Latin letters.
    //Both start with an upper letter and are followed by lower letters.
    //The two words are separated by a single space (ex. "John Smith") (required)
    //•	Email – text(required)
    //•	Age – integer in the range[3, 103] (required)
    //•	Cards – collection of type Card

    public class CardInputModel
    {
        [Required]
        [RegularExpression(@"[0-9]{4}\s[0-9]{4}\s[0-9]{4}\s[0-9]{4}")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{3}")]
        public string CVC { get; set; }

        public CardType Type { get; set; }
    }
}

//•	Number – text, which consists of 4 pairs of 4 digits,
//separated by spaces (ex. “1234 5678 9012 3456”) (required)
//•	Cvc – text, which consists of 3 digits (ex. “123”) (required)
//•	Type – enumeration of type CardType, with possible values (“Debit”, “Credit”) (required)
//•	UserId – integer, foreign key(required)
//•	User – the card’s user (required)
//•	Purchases – collection of type Purchase

//{
//	"FullName": "",
//		"Username": "invalid",
//		"Email": "invalid@invalid.com",
//		"Age": 20,
//		"Cards": [
//			{
//		"Number": "1111 1111 1111 1111",
//				"CVC": "111",
//				"Type": "Debit"
//			}
//		]
//	},
