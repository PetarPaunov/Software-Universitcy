using AutoMapper;
using CarDealer.DtoModels.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<SuppliersImportModel, Supplier>();
        }
    }
}
