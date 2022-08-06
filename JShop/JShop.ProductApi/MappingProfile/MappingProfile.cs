using AutoMapper;
using JShop.ProductApi.Dtos;
using JShop.ProductApi.Models;

namespace JShop.ProductApi.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
