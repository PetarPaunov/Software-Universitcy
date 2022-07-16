using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DataTransferObjectModels;
using ProductShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            /*
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            
            
            var usersJson = File.ReadAllText("../../../Datasets/users.json");
            ImportUsers(db, usersJson);
            
            var productsJson = File.ReadAllText("../../../Datasets/products.json");
            ImportProducts(db, productsJson);

            var categoryJson = File.ReadAllText("../../../Datasets/categories.json");
            ImportCategories(db, categoryJson);

            var categoryProductsJson = File.ReadAllText("../../../Datasets/categories-products.json");
            ImportCategoryProducts(db, categoryProductsJson);
            */

            var result = GetUsersWithProducts(db);

            Console.WriteLine(result);
        }



        // 08. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(x => x.ProductsSold)
                .ToList()
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = new
                    {
                        count = x.ProductsSold.Where(b => b.BuyerId != null).Count(),
                        products = x.ProductsSold.Where(b => b.BuyerId != null)
                        .Select(b => new
                        {

                            name = b.Name,
                            price = b.Price,
                        }),
                    }
                })
                .OrderByDescending(x => x.soldProducts.products.Count())
                .ToList();

            var resultObject = new
            {
                usersCount = users.Count(),
                users = users
            };

            var result = JsonConvert.SerializeObject(resultObject, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            return result;
        }

        // 07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count(),
                    averagePrice = x.CategoryProducts.Average(P => P.Product.Price).ToString("F2"),
                    totalRevenue = x.CategoryProducts.Sum(ps => ps.Product.Price).ToString("F2")
                })
                .OrderByDescending(x => x.productsCount)
                .ToList();

            var result = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return result;
        }

        // 06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold
                    .Where(bp => bp.BuyerId != null)
                    .Select(b => new
                    {
                        name = b.Name,
                        price = b.Price,
                        buyerFirstName = b.Buyer.FirstName,
                        buyerLastName = b.Buyer.LastName,
                    })
                })
                .OrderBy(x => x.lastName)
                .ThenBy(x => x.firstName)
                .ToList();

            var result = JsonConvert.SerializeObject(users, Formatting.Indented);

            return result;
        }

        // 05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new 
                {
                    name = x.Name,
                    price = x.Price,
                    seller = x.Seller.FirstName + ' ' + x.Seller.LastName
                })
                .OrderBy(x => x.price)
                .ToList();

            var result = JsonConvert.SerializeObject(products, Formatting.Indented);
            return result;
        }

        // 04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dtoCategoryProducts = JsonConvert.
                DeserializeObject<IEnumerable<CategoryProductsInputDTO>>(inputJson);

            var categoryProducts = mapper.Map<IEnumerable<CategoryProduct>>(dtoCategoryProducts);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        // 03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dtoCategories = JsonConvert.DeserializeObject<IEnumerable<Category>>(inputJson);

            var categories = mapper.Map<IEnumerable<Category>>(dtoCategories);

            foreach (var category in categories)
            {
                if (category.Name != null)
                {
                    context.Categories.Add(category);
                }
            }
            context.SaveChanges();

            return $"Successfully imported {categories.Where(x => x.Name != null).Count()}";
        }

        // 2. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dtoProducts = JsonConvert.DeserializeObject<IEnumerable<ProductsInputDTO>>(inputJson);

            var products = mapper.Map<IEnumerable<Product>>(dtoProducts);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        // 01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dtoUsers = JsonConvert.DeserializeObject<IEnumerable<UserInputDTO>>(inputJson);

            var users = mapper.Map<IEnumerable<User>>(dtoUsers);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}