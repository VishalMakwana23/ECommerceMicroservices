using ECommerce.OrderAPI.DTOs;

namespace ECommerce.OrderAPI.Services
{
    public interface IProductService
    {
        Task<ProductDto?> GetProductById(int id);
    }
}
