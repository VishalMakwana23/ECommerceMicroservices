namespace ECommerce.OrderAPI.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedAt { get; set; }

        public ProductDto? Product { get; set; }
    }
}
