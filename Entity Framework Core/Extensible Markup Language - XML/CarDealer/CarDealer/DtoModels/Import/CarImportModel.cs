using System.Xml.Serialization;

namespace CarDealer.DtoModels.Import
{
    [XmlType("Car")]
    public class CarImportModel
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TraveledDistance { get; set; }

        [XmlArray("parts")]
        public PartsModel[] Parts { get; set; }
    }

    [XmlType("partId")]
    public class PartsModel
    {
        [XmlAttribute("id")]
        public int PartId { get; set; }
    }
}
