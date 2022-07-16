using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static IMapper mapper;
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            /*
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var suppliersJson = File.ReadAllText("../../../Datasets/suppliers.json");
            ImportSuppliers(db, suppliersJson);

            var partsJson = File.ReadAllText("../../../Datasets/parts.json");
            ImportParts(db, partsJson);

            var carsJson = File.ReadAllText("../../../Datasets/cars.json");
            ImportCars(db, carsJson);

            var customersJson = File.ReadAllText("../../../Datasets/customers.json");
            ImportCustomers(db, customersJson);

            var salesJson = File.ReadAllText("../../../Datasets/sales.json");
            ImportSales(db, salesJson);
            */

            var result = GetSalesWithAppliedDiscount(db);
            Console.WriteLine(result);
        }


        // 19. Export Sales With Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(x => new
                {
                    car = new
                    {
                        x.Car.Make,
                        x.Car.Model,
                        x.Car.TravelledDistance
                    },
                    customerName = x.Customer.Name,
                    Discount = x.Discount.ToString("F2"),
                    price = $"{(x.Car.PartCars.Sum(p => p.Part.Price)):F2}",
                    priceWithDiscount = $"{x.Car.PartCars.Sum(p => p.Part.Price) - x.Car.PartCars.Sum(pp => pp.Part.Price) * (x.Discount / 100):F2}"
                })
                .Take(10)
                .ToList();

            var result = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return result;
        }

        // 18. Export Total Sales By Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(x => x.Sales.Any(c => c.Car != null))
                .Select(x => new
                {
                    fullName = x.Name,
                    boughtCars = x.Sales.Select(bc => bc.Car).Count(),
                    spentMoney = x.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToList();

            var result = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return result;
        }

        // 17. Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(x => new
                {
                    car = new
                    {
                        x.Make,
                        x.Model,
                        x.TravelledDistance
                    },
                    parts = x.PartCars.Select(p => new
                    {
                        p.Part.Name,
                        Price = p.Part.Price.ToString("F2")
                    })
                })
                .ToList();

            var result = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return result;
        }

        // 16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var supplies = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    PartsCount = x.Parts.Count()
                })
                .ToList();

            var result = JsonConvert.SerializeObject(supplies, Formatting.Indented);

            return result;
        }

        // 15. Export Cars From Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "Toyota")
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToList();

            var result = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return result;
        }

        // 14. Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = x.IsYoungDriver
                })
                .ToList();

            var result = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return result;
        }

        // 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();

            var salesModel = JsonConvert.DeserializeObject<IEnumerable<SalesModel>>(inputJson);

            var sales = mapper.Map<IEnumerable<Sale>>(salesModel);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        // 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();

            var customerModel = JsonConvert.DeserializeObject<IEnumerable<CustomersModel>>(inputJson);

            var customers = mapper.Map<IEnumerable<Customer>>(customerModel);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        // 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsModel = JsonConvert.DeserializeObject<IEnumerable<CarsModel>>(inputJson);

            var listOfCars = new List<Car>();

            foreach (var car in carsModel)
            {
                var currentCar = new Car()
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.travelledDistance
                };

                foreach (var partsId in car?.partsId.Distinct())
                {
                    currentCar.PartCars.Add(new PartCar
                    {
                        PartId = partsId
                    });
                }

                listOfCars.Add(currentCar);
            }

            context.Cars.AddRange(listOfCars);
            context.SaveChanges();

            return $"Successfully imported {listOfCars.Count}.";
        }

        // 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();

            var suppliers = context.Suppliers
                .Select(x => x.Id)
                .ToList();

            var partsModel = JsonConvert.DeserializeObject<IEnumerable<Part>>(inputJson)
                .Where(s => suppliers.Contains(s.SupplierId))
                .ToList();

            var parts = mapper.Map<IEnumerable<Part>>(partsModel);

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        // 09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();
            var suppliersModel = JsonConvert.DeserializeObject<IEnumerable<SuppliersModel>>(inputJson);

            var suppliers = mapper.Map<IEnumerable<Supplier>>(suppliersModel);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}