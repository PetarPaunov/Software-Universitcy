using System.Xml.Serialization;

namespace ProductShop.DataTransferObjects.Exports
{
    [XmlType("Product")]
    public class SoldProductsModel
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}

//< Product >
//        < name > olio activ mouthwash</name>
//        <price>206.06</price>
//      </Product>
