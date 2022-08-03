using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType("Gun")]
    public class ExportGunsModel
    {
        [XmlAttribute("Manufacturer")]
        public string Manufacturer { get; set; }

        [XmlAttribute("GunType")]
        public string GunType { get; set; }

        [XmlAttribute("GunWeight")]
        public int GunWeight { get; set; }

        [XmlAttribute("BarrelLength")]
        public double BarrelLength { get; set; }

        [XmlAttribute("Range")]
        public int Range { get; set; }

        [XmlArray("Countries")]
        public ExportCoutnriesModel[] Countries { get; set; }
    }

    [XmlType("Country")]
    public class ExportCoutnriesModel
    {
        [XmlAttribute("Country")]
        public string Country { get; set; }

        [XmlAttribute("ArmySize")]
        public int ArmySize { get; set; }
    }
}

  //< Gun Manufacturer = "Krupp"
  //      GunType = "AntiAircraftGun"
  //      GunWeight = "1280923"
  //      BarrelLength = "10.89"
  //      Range = "16530" >
  //  < Countries >
  //    < Country Country = "Albania" ArmySize = "6296389" />
  //    < Country Country = "United Kingdom" ArmySize = "7242451" />
  //    < Country Country = "China" ArmySize = "9944746" />
  //  </ Countries >
  //</ Gun >

