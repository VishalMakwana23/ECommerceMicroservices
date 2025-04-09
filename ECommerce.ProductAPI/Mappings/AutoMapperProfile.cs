using AutoMapper;
using ECommerce.ProductAPI.DTOs;
using ECommerce.ProductAPI.Models;

namespace ECommerce.ProductAPI.Mappings
{
    public class AutoMapperProfile : Profile  // Profile: Inherit from AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
        }
    }
}
