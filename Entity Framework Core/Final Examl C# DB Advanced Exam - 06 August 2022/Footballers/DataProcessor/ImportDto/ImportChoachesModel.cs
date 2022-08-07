using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Coach")]
    public class ImportChoachesModel
    {
        [Required]
        [StringLength(40, MinimumLength = 2)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [XmlElement("Nationality")]
        public string Nationality { get; set; }

        [XmlArray("Footballers")]
        public ImportFootballersModel[] Footballers { get; set; }
    }

    //•	Id – integer, Primary Key
    //•	Name – text with length [2, 40] (required)
    //•	Nationality – text(required)
    //•	Footballers – collection of type Footballer

    [XmlType("Footballer")]
    public class ImportFootballersModel
    {
        [Required]
        [StringLength(40, MinimumLength = 2)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [XmlElement("ContractStartDate")]
        public string ContractStartDate { get; set; }

        [Required]
        [XmlElement("ContractEndDate")]
        public string ContractEndDate { get; set; }

        [XmlElement("BestSkillType")]
        public int BestSkillType { get; set; }

        [XmlElement("PositionType")]
        public int PositionType { get; set; }
    }
}
//•	PositionType – enumeration of type PositionType, with possible values (Goalkeeper, Defender, Midfielder, Forward) (required)
//•	BestSkillType – enumeration of type BestSkillType, with possible values (Defence, Dribble, Pass, Shoot, Speed) (required)
//•	CoachId – integer, foreign key(required)
//•	Coach – Coach 
//•	TeamsFootballers – collection of type TeamFootballer


//< Coach >
//    < Name > S </ Name >
//    < Nationality > 25 / 01 / 2018 </ Nationality >
//    < Footballers >
//      < Footballer >
//        < Name > Benjamin Bourigeaud </ Name >
//        < ContractStartDate > 22 / 03 / 2020 </ ContractStartDate >
//        < ContractEndDate > 24 / 02 / 2026 </ ContractEndDate >
//        < BestSkillType > 2 </ BestSkillType >
//        < PositionType > 2 </ PositionType >
//      </ Footballer >

