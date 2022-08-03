using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Manufacturer")]
    public class ImportManufactorersModel
    {
        [Required]
        [StringLength(40, MinimumLength = 4)]
        [XmlElement("ManufacturerName")]
        public string ManufacturerName { get; set; }


        [Required]
        [StringLength(100, MinimumLength = 10)]
        [XmlElement("Founded")]
        public string Founded { get; set; }
    }
}

//•	Id – integer, Primary Key
//•	ManufacturerName – unique text with length [4…40] (required)
//•	Founded – text with length [10…100] (required)
//•	Guns – a collection of Gun

//< Manufacturer >
//    < ManufacturerName > BAE Systems </ ManufacturerName >
//    < Founded > 30 November 1999, London, England </ Founded >
//  </ Manufacturer >

