namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCountriesModel[]), new XmlRootAttribute("Countries"));

            var stringReader = new StringReader(xmlString);

            var countriesDto = xmlSerializer.Deserialize(stringReader) as ImportCountriesModel[];

            var sb = new StringBuilder(); 

            foreach (var coutry in countriesDto)
            {
                if (!IsValid(coutry))
                {
                    sb.AppendLine("Invalid data.");
                    continue;
                }

                var currentCountrie = new Country
                {
                    CountryName = coutry.CountryName,
                    ArmySize = coutry.ArmySize
                };

                context.Countries.Add(currentCountrie);
                context.SaveChanges();
                sb.AppendLine($"Successfully import {coutry.CountryName} with {coutry.ArmySize} army personnel.");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportManufactorersModel[]), new XmlRootAttribute("Manufacturers"));

            var stringReader = new StringReader(xmlString);

            var manufacturersDto = xmlSerializer.Deserialize(stringReader) as ImportManufactorersModel[];

            var sb = new StringBuilder();

            foreach (var manufacture in manufacturersDto)
            {
                if (!IsValid(manufacture))
                {
                    sb.AppendLine("Invalid data.");
                    continue;
                }

                var currentManufacturer = new Manufacturer
                {
                    ManufacturerName = manufacture.ManufacturerName,
                    Founded = manufacture.Founded
                };

                if (context.Manufacturers.Any(x => x.ManufacturerName == currentManufacturer.ManufacturerName))
                {
                    sb.AppendLine("Invalid data.");
                    continue;
                }

                context.Manufacturers.Add(currentManufacturer);
                context.SaveChanges();

                var townCountrie = manufacture.Founded.Split(", ").TakeLast(2).ToArray();

                sb.AppendLine($"Successfully import manufacturer {manufacture.ManufacturerName} founded in {townCountrie[0]}, {townCountrie[1]}.");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportShellsModel[]), new XmlRootAttribute("Shells"));

            var stringReader = new StringReader(xmlString);

            var shellsDto = xmlSerializer.Deserialize(stringReader) as ImportShellsModel[];

            var sb = new StringBuilder();

            foreach (var shell in shellsDto)
            {
                if (!IsValid(shell))
                {
                    sb.AppendLine("Invalid data.");
                    continue;
                }

                var currentShell = new Shell
                {
                    ShellWeight = shell.ShellWeight,
                    Caliber = shell.Caliber
                };

                context.Shells.Add(currentShell);
                context.SaveChanges();

                sb.AppendLine($"Successfully import shell caliber #{shell.Caliber} weight {shell.ShellWeight} kg.");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var gunsDto = JsonConvert.DeserializeObject<ImportGunsModel[]>(jsonString);

            var sb = new StringBuilder();

            foreach (var gun in gunsDto)
            {
                if (!IsValid(gun))
                {
                    sb.AppendLine("Invalid data.");
                    continue;
                }

                var currentGun = new Gun
                {
                    ManufacturerId = gun.ManufacturerId,
                    GunWeight = gun.GunWeight,
                    BarrelLength = gun.BarrelLength,
                    NumberBuild = gun.NumberBuild,
                    Range = gun.Range,
                    GunType = Enum.Parse<GunType>(gun.GunType),
                    ShellId = gun.ShellId,
                };

                foreach (var countryGun in gun.Countries)
                {
                    var currentCoutry = new CountryGun { CountryId = countryGun.Id };
                    currentGun.CountriesGuns.Add(currentCoutry);
                }

                context.Guns.Add(currentGun);
                context.SaveChanges();

                sb.AppendLine($"Successfully import gun {gun.GunType} with a total weight of {gun.GunWeight} kg. and barrel length of {gun.BarrelLength} m.");
            }

            return sb.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
