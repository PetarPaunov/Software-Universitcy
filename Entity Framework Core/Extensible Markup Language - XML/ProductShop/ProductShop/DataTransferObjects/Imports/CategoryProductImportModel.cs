using System.Xml.Serialization;

namespace ProductShop.DataTransferObjects.Imports
{
    [XmlType("CategoryProduct")]
    public class CategoryProductImportModel
    {
        public int CategoryId { get; set; }

        public int ProductId { get; set; }
    }
}

    //< CategoryProduct >
    //    < CategoryId > 4 </ CategoryId >
    //    < ProductId > 1 </ ProductId >
    //</ CategoryProduct >
