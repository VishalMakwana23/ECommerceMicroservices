﻿namespace ECommerce.OrderAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
