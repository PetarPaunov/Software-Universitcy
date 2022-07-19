using AutoMapper;
using ProductShop.DataTransferObjects.Imports;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserImportModel, User>();
            this.CreateMap<ProductImportModel, Product>();
            this.CreateMap<CategoriesImportModel, Category>();
            this.CreateMap<CategoryProductImportModel, CategoryProduct>();
        }
    }
}
