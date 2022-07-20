using System.Xml.Serialization;

namespace ProductShop.DataTransferObjects.Exports
{
    public class UsersCountModel
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public UsersModel[] Users { get; set; }
    }

    [XmlType("User")]
    public class UsersModel
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlElement("SoldProducts")]
        public SoldProductsUsersModel SoldProducts { get; set; }
    }

    [XmlType("SoldProducts")] // 
    public class SoldProductsUsersModel
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public ProductsModel[] Products { get; set; }
    }

    [XmlType("Product")]
    public class ProductsModel
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

    }
}