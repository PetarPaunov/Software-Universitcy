using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProductShop.DataTransferObjects.Exports
{
    [XmlType("User")]
    public class SoldProductsOutputModel
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlArray("soldProducts")]
        public SoldProductsModel[] Products { get; set; }
    }
}

