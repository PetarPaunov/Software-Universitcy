using System.Xml.Serialization;

namespace CarDealer.DtoModels.Export
{
    [XmlType("car")]
    public class CarsWithPartsExportModel
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long Travalled { get; set; }

        [XmlArray("parts")]
        public PartsForCarsModel[] Parts { get; set; }
    }

    [XmlType("part")]
    public class PartsForCarsModel
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}

