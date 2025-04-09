using AutoMapper;
using ECommerce.OrderAPI.DTOs;
using ECommerce.OrderAPI.Models;

namespace ECommerce.OrderAPI.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
        }
    }
}
