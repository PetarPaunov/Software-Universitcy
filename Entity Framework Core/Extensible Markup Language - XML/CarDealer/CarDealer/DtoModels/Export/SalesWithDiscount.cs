﻿using System.Xml.Serialization;

namespace CarDealer.DtoModels.Export
{
    [XmlType("sale")]
    public class SalesWithDiscount
    {
        [XmlElement("car")]
        public CarWithDisount Car { get; set; }

        [XmlElement("discount")]
        public decimal Discount { get; set; }

        [XmlElement("customer-name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("price-with-discount")]
        public decimal PriceWithDiscount { get; set; }
    }

    [XmlType("car")]
    public class CarWithDisount
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}

