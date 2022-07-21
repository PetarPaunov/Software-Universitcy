using AutoMapper;
using CarDealer.Data;
using CarDealer.DtoModels.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static IMapper mapper;
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var supplierXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            ImportSuppliers(db, supplierXml);

            var partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            ImportParts(db, partsXml);

            var carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            var result = ImportCars(db, carsXml);

            Console.WriteLine(result);
        }


        // 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CarImportModel[]), new XmlRootAttribute("Cars"));

            var textReader = new StringReader(inputXml);

            var carsDto = xmlSerializer.Deserialize(textReader) as CarImportModel[];

            var carList = new List<Car>();

            var partsId = context.Parts.Select(x => x.Id).ToArray();

            foreach (var currentCar in carsDto)
            {
                var distinctParts = currentCar.Parts.Select(x => x.PartId).Distinct();
                var parts = distinctParts.Intersect(partsId);

                var car = new Car
                {
                    Make = currentCar.Make,
                    Model = currentCar.Model,
                    TravelledDistance = currentCar.TraveledDistance
                };

                foreach (var patrs in parts)
                {
                    var part = new PartCar
                    {
                        PartId = patrs
                    };

                    car.PartCars.Add(part);
                }

                carList.Add(car);
            }

            context.Cars.AddRange(carList);
            context.SaveChanges();

            return $"Successfully imported {carList.Count}";
        }

        // 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();

            var suppliersId = context.Suppliers.Select(x => x.Id).ToArray();

            var xmlSerializer = new XmlSerializer(typeof(PartsImportModel[]), new XmlRootAttribute("Parts"));

            var textReader = new StringReader(inputXml);

            var partsDto = xmlSerializer.Deserialize(textReader) as PartsImportModel[];

            var parts = partsDto.Where(x => suppliersId.Contains(x.SupplierId))
                .Select(x => new Part
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    SupplierId = x.SupplierId
                })
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        // 09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();

            var xmlSerializer = new XmlSerializer(typeof(SuppliersImportModel[]), new XmlRootAttribute("Suppliers"));

            var textReader = new StringReader(inputXml);

            var suppliersDto = xmlSerializer.Deserialize(textReader) as SuppliersImportModel[];

            var suppliers = mapper.Map<Supplier[]>(suppliersDto);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliersDto.Length}";
        }

        static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}