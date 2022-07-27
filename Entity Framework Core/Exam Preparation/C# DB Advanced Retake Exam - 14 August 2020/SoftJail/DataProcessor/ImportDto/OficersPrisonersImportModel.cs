using SoftJail.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class OficersPrisonersImportModel
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [XmlElement("Money")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Money { get; set; }

        [XmlElement("Position")]
        [EnumDataType(typeof(Position))]
        public string Position { get; set; }

        [XmlElement("Weapon")]
        [EnumDataType(typeof(Weapon))]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public PrisonersImportModel[] Prisoners { get; set; }
    }

    [XmlType("Prisoner")]
    public class PrisonersImportModel
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

    }
}


//< Officer >
//		< Name > Minerva Kitchingman </ Name >
//		< Money > 2582 </ Money >
//		< Position > Invalid </ Position >
//		< Weapon > ChainRifle </ Weapon >
//		< DepartmentId > 2 </ DepartmentId >
//		< Prisoners >
//			< Prisoner id = "15" />
//		</ Prisoners >
//	</ Officer >
