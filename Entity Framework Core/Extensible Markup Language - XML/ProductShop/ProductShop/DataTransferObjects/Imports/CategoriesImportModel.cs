using System.Xml.Serialization;

namespace ProductShop.DataTransferObjects.Imports
{
    [XmlType("Category")]
    public class CategoriesImportModel
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
}