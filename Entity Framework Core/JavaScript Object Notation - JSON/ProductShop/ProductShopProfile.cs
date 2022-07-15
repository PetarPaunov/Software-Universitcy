using AutoMapper;
using ProductShop.DataTransferObjectModels;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserInputDTO, User>();
            this.CreateMap<ProductsInputDTO, Product>();
            this.CreateMap<CategoryInputDTO, Category>();
            this.CreateMap<CategoryProductsInputDTO, CategoryProduct>();
        }
    }
}
