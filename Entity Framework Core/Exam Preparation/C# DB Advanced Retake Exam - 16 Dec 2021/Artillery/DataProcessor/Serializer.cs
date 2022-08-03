
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.DataProcessor.ExportDto;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shlls = context
                .Shells
                .Where(x => x.ShellWeight > shellWeight)
                .ToArray()
                .Select(x => new
                {
                    ShellWeight = x.ShellWeight,
                    Caliber = x.Caliber,
                    Guns = x.Guns
                        .Where(g => g.GunType.ToString() == "AntiAircraftGun")
                        .Select(g => new
                        {
                            GunType = g.GunType.ToString(),
                            GunWeight = g.GunWeight,
                            BarrelLength = g.BarrelLength,
                            Range = g.Range > 3000 ? "Long-range" : "Regular range"
                        })
                        .OrderByDescending(g => g.GunWeight)
                        .ToArray()
                })
                .OrderBy(x => x.ShellWeight)
                .ToArray();

            var result = JsonConvert.SerializeObject(shlls, Formatting.Indented);

            return result.ToString();
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            var guns = context
                .Guns
                .Where(x => x.Manufacturer.ManufacturerName == manufacturer)
                .ToArray()
                .Select(x => new ExportGunsModel
                {
                    Manufacturer = x.Manufacturer.ManufacturerName,
                    GunType = x.GunType.ToString(),
                    GunWeight = x.GunWeight,
                    BarrelLength = x.BarrelLength,
                    Range = x.Range,
                    Countries = x.CountriesGuns
                        .Where(c => c.Country.ArmySize > 4500000)
                        .Select(c => new ExportCoutnriesModel
                        {
                            Country = c.Country.CountryName,
                            ArmySize = c.Country.ArmySize
                        })
                        .OrderBy(c => c.ArmySize)
                        .ToArray()
                })
                .OrderBy(x => x.BarrelLength)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportGunsModel[]), new XmlRootAttribute("Guns"));

            var stringWriter = new StringWriter();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(stringWriter, guns, namespaces);

            return stringWriter.ToString();
        }
    }
}
