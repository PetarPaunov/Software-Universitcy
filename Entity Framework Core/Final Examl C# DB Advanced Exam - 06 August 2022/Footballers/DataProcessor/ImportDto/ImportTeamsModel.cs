using System.ComponentModel.DataAnnotations;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamsModel
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-z0-9\s.-]*$")]
        public string Name { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Nationality { get; set; }

        public int Trophies { get; set; }

        public int[] Footballers { get; set; }
    }

    //•	Id – integer, Primary Key
    //•	Name – text with length [3, 40].. (required)
    //•	Nationality – text with length [2, 40] (required)
    //•	Trophies – integer(required)
    //•	TeamsFootballers – collection of type TeamFootballer
}

//"Name": "Brentford F.C.",
//    "Nationality": "The United Kingdom",
//    "Trophies": "5",
//    "Footballers": [
//      28,
//      28,
//      39,
//      57
//    ]

