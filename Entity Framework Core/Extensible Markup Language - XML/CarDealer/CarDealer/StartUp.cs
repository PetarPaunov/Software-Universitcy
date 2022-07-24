using AutoMapper;
using CarDealer.Data;
using CarDealer.DtoModels.Export;
using CarDealer.DtoModels.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static IMapper mapper;
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();

            /*
            var supplierXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            ImportSuppliers(db, supplierXml);

            var partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            ImportParts(db, partsXml);

            var carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            ImportCars(db, carsXml);

            var customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            ImportCustomers(db, customersXml);

            var salesXml = File.ReadAllText("../../../Datasets/sales.xml");
            ImportSales(db, salesXml);
            */

            var result = GetSalesWithAppliedDiscount(db);

            Console.WriteLine(result);

        }

        // 19. Export Sales With Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(x => new SalesWithDiscount
                {
                    Car = new CarWithDisount
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    Discount = x.Discount,
                    Name = x.Customer.Name,
                    Price = x.Car.PartCars.Sum(x => x.Part.Price),
                    PriceWithDiscount = x.Car.PartCars.Sum(x => x.Part.Price) * (1 - x.Discount / 100)
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(SalesWithDiscount[]), new XmlRootAttribute("sales"));

            var textWriter = new StringWriter();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(textWriter, sales, namespaces);

            return textWriter.ToString();
        }

        // 18. Export Total Sales By Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(x => x.Sales.Any(s => s.CustomerId == x.Id))
                .Select(x => new TotalSalesByCustomerModel
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count(),
                    SpentMoney = x.Sales
                    .Select(x => x.Car)
                    .SelectMany(x => x.PartCars)
                    .Sum(x => x.Part.Price)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(TotalSalesByCustomerModel[]), new XmlRootAttribute("customers"));

            var textWriter = new StringWriter();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(textWriter, customers, namespaces);

            return textWriter.ToString();
        }

        // 17. Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .Select(x => new CarsWithPartsExportModel
                {
                    Make = x.Make,
                    Model = x.Model,
                    Travalled = x.TravelledDistance,
                    Parts = x.PartCars.Select(x => new PartsForCarsModel
                    {
                        Name = x.Part.Name,
                        Price = x.Part.Price
                    })
                    .OrderByDescending(x => x.Price)
                    .ToArray()
                })
                .OrderByDescending(x => x.Travalled)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(CarsWithPartsExportModel[]), new XmlRootAttribute("cars"));

            var textWriter = new StringWriter();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(textWriter, carsWithParts, namespaces);

            return textWriter.ToString();
        }

        // 16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new LocalSuppliersModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count()
                })
                .ToArray();


            var xmlSerializer = new XmlSerializer(typeof(LocalSuppliersModel[]), new XmlRootAttribute("suppliers"));

            var textWriter = new StringWriter();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(textWriter, suppliers, namespaces);

            return textWriter.ToString();
        }

        // 15. Export Cars From Make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "BMW")
                .Select(x => new BmwCardsExportModel
                {
                    Id = x.Id,
                    Model = x.Model,
                    Travalled = x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.Travalled)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(BmwCardsExportModel[]), new XmlRootAttribute("cars"));

            var textWriter = new StringWriter();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(textWriter, cars, namespaces);

            return textWriter.ToString();
        }

        // 14. Export Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {

            var cars = context.Cars
                .Where(x => x.TravelledDistance > 2_000_000)
                .Select(x => new CarsWithDistanceExportModel
                {
                    Model = x.Model,
                    Make = x.Make,
                    Travelled = x.TravelledDistance
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(CarsWithDistanceExportModel[]), new XmlRootAttribute("cars"));

            var textWriter = new StringWriter();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(textWriter, cars, namespaces);

            return textWriter.ToString();

        }

        // 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(SalesImportModel[]), new XmlRootAttribute("Sales"));

            var textReader = new StringReader(inputXml);

            var salesDto = xmlSerializer.Deserialize(textReader) as SalesImportModel[];

            var carsId = context.Cars.Select(x => x.Id).ToArray();

            var sales = salesDto.Where(x => carsId.Contains(x.CarId))
                .Select(x => new Sale
                {
                    CarId = x.CarId,
                    CustomerId = x.CustomerId,
                    Discount = x.Discount
                });

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        }

        // 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCustomersModel[]), new XmlRootAttribute("Customers"));

            var textReadr = new StringReader(inputXml);

            var customersDto = xmlSerializer.Deserialize(textReadr) as ImportCustomersModel[];

            var customers = customersDto.Select(x => new Customer
            {
                Name = x.Name,
                BirthDate = x.BirthDate,
                IsYoungDriver = x.IsYoungDriver
            });

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";
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