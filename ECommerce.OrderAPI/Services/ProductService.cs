using ECommerce.OrderAPI.DTOs;

namespace ECommerce.OrderAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public ProductService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<ProductDto?> GetProductById(int id)
        {
            var baseUrl = _config["ServiceUrls:ProductAPI"];
            var response = await _httpClient.GetAsync($"{baseUrl}/api/products/{id}");
            if (!response.IsSuccessStatusCode) return null;
            return await response.Content.ReadFromJsonAsync<ProductDto>();
        }

    }
}
