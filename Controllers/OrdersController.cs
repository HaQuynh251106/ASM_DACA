using ASM_Bai2.Services.Interfaces; // Nhớ using Service Interface
using Microsoft.AspNetCore.Mvc;
using System;

namespace ASM_Bai2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // Bây giờ Controller gọi Service, KHÔNG gọi Repository nữa
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("details/{orderId}")]
        public IActionResult GetOrderDetails(int orderId)
        {
            try
            {
                var result = _orderService.GetOrderDetails(orderId);
                if (result == null || result.Count == 0) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("with-customer")]
        public IActionResult GetOrdersWithCustomer()
        {
            return Ok(_orderService.GetOrdersWithCustomer());
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] int customerId)
        {
            try
            {
                var newId = _orderService.CreateOrder(customerId);
                if (newId > 0) return Ok(new { OrderId = newId });
                return BadRequest("Không tạo được đơn hàng");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            // Service đã tự map sang OrderDto rồi, Controller chỉ việc trả về
            return Ok(_orderService.GetAllOrders());
        }
    }
}