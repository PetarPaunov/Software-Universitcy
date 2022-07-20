using ProductShop.Data;
using ProductShop.DataTransferObjects.Imports;
namespace ProductShop
{
    using AutoMapper;
    using ProductShop.DataTransferObjects.Exports;
    using ProductShop.Models;
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static IMapper mapper;
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            /*
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var usersXml = File.ReadAllText("../../../Datasets/users.xml");
            ImportUsers(db, usersXml);

            var productsXml = File.ReadAllText("../../../Datasets/products.xml");
            ImportProducts(db, productsXml);

            var categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            ImportCategories(db, categoriesXml);

            var categoriesProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            ImportCategoryProducts(db, categoriesProductsXml);
            */

            //GetSoldProducts(db);

            var result = GetUsersWithProducts(db);
            Console.WriteLine(result);
        }


        // 08. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .ToArray()
                .Where(x => x.ProductsSold.Any(sp => sp.BuyerId != null))
                .Select(x => new UsersModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new SoldProductsUsersModel
                    {
                        Count = x.ProductsSold.Count(),
                        Products = x.ProductsSold.Select(p => new ProductsModel
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray(),
                    }
                })
                .OrderByDescending(x => x.SoldProducts.Count)
                .Take(10)
                .ToArray();

            var result = new UsersCountModel
            {
                Count = context.Users.Count(x => x.ProductsSold.Any(p => p.BuyerId != 0)),
                Users = users
            };

            var xmlSerializer = new XmlSerializer(typeof(UsersCountModel), new XmlRootAttribute("Users"));

            var textWriter = new StringWriter();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(textWriter, result, namespaces);

            return textWriter.ToString();
        }

        // 07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new CategoryByProductModel
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count(),
                    AveragePrice = x.CategoryProducts.Average(p => p.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(CategoryByProductModel[]), new XmlRootAttribute("Categories"));

            var textWriter = new StringWriter();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(textWriter, categories, namespaces);

            return textWriter.ToString();
        }

        // 06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                .Select(x => new SoldProductsOutputModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Products = x.ProductsSold.Select(p => new SoldProductsModel
                    {
                        Name = p.Name,
                        Price = p.Price,
                    })
                    .ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(SoldProductsOutputModel[]), new XmlRootAttribute("Users"));

            var textWriter = new StringWriter();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(textWriter, users, namespaces);

            return textWriter.ToString();
        }

        // 05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new ProductsOutputModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    BuyerName = x.Buyer.FirstName + ' ' + x.Buyer.LastName
                })
                .OrderBy(x => x.Price)
                .Take(10)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ProductsOutputModel[]), new XmlRootAttribute("Products"));

            var textWriter = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            xmlSerializer.Serialize(textWriter, products, ns);

            return textWriter.ToString();
        }

        // 04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();

            var xmlSerializer = new XmlSerializer(typeof(CategoryProductImportModel[]), new XmlRootAttribute("CategoryProducts"));

            var textReader = new StringReader(inputXml);

            var categoriesProductsDto = xmlSerializer.Deserialize(textReader) as CategoryProductImportModel[];

            var categories = mapper.Map<CategoryProduct[]>(categoriesProductsDto);

            context.CategoryProducts.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categoriesProductsDto.Count()}";
        }

        // 03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();

            var xmlSerializer = new XmlSerializer(typeof(CategoriesImportModel[]), new XmlRootAttribute("Categories"));

            var textReader = new StringReader(inputXml);

            var categoriesDto = xmlSerializer.Deserialize(textReader) as CategoriesImportModel[];

            var categories = mapper.Map<Category[]>(categoriesDto);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categoriesDto.Count()}";
        }

        // 02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();

            var xlmSerialize = new XmlSerializer(typeof(ProductImportModel[]), new XmlRootAttribute("Products"));

            var textReader = new StringReader(inputXml);

            var productDto = xlmSerialize.Deserialize(textReader) as ProductImportModel[];

            var products = mapper.Map<Product[]>(productDto);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {productDto.Count()}";
        }

        // 01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();

            var xmlSerializer = new XmlSerializer(typeof(UserImportModel[]), new XmlRootAttribute("Users"));

            var textReader = new StringReader(inputXml);

            var usersDto = xmlSerializer.Deserialize(textReader) as UserImportModel[];

            var users = mapper.Map<User[]>(usersDto);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {usersDto.Count()}";
        }

        static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper(); 
        }
    }
}