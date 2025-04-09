using AutoMapper;
using ECommerce.OrderAPI.Data;
using ECommerce.OrderAPI.DTOs;
using ECommerce.OrderAPI.Models;
using ECommerce.OrderAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.OrderAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        
        private readonly OrderDbContext _context;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public OrdersController(OrderDbContext context, IMapper mapper, IProductService productService)
        {
            _context = context;
            _mapper = mapper;
            _productService = productService;
        }

        // GET: api/orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
        {
            var orders = await _context.Orders.ToListAsync();

            var orderDtos = _mapper.Map<List<OrderDto>>(orders);

            foreach (var dto in orderDtos)
            {
                var product = await _productService.GetProductById(dto.ProductId);
                dto.Product = product;
            }

            return Ok(orderDtos);
        }

        // GET: api/orders/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return NotFound();

            var orderDto = _mapper.Map<OrderDto>(order);

            var product = await _productService.GetProductById(order.ProductId);
            orderDto.Product = product;

            return Ok(orderDto);

        }

        // POST: api/orders
        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrder([FromBody] CreateOrderDto createOrderDto)
        {

            // Validate product from ProductAPI
            var product = await _productService.GetProductById(createOrderDto.ProductId);
            if (product == null)
            {
                return BadRequest($"Product with ID {createOrderDto.ProductId} not found.");
            }

            var order = _mapper.Map<Order>(createOrderDto);
            order.CreatedAt = DateTime.UtcNow;
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, _mapper.Map<OrderDto>(order));
        }

        // PUT: api/orders/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, CreateOrderDto updateDto)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();

            _mapper.Map(updateDto, order);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/orders/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
