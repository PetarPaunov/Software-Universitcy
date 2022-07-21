using System.Xml.Serialization;

namespace CarDealer.DtoModels.Import
{
    [XmlType("Supplier")]
    public class SuppliersImportModel
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("isImporter")]
        public bool IsImporter { get; set; }
    }
}

//< Supplier >
//        < name > 3M Company </ name >
//        < isImporter > true </ isImporter >
//    </ Supplier >