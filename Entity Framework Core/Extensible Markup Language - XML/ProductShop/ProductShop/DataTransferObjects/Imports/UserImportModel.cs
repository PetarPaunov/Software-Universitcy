using System;
using System.Xml.Serialization;

namespace ProductShop.DataTransferObjects.Imports
{
    [Serializable]
    [XmlType("User")]
    public class UserImportModel
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }
    }
}
