using ASM_Bai2.DTOs;
using ASM_Bai2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASM_Bai2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCustomerDto dto)
        {
            _service.Create(dto);
            return Ok(new { Message = "Tạo khách hàng thành công" });
        }
    }
}