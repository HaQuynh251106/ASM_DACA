using ASM_Bai2.DTOs;
using ASM_Bai2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASM_Bai2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CategoryDto dto)
        {
            _service.Create(dto);
            return Ok(new { Message = "Tạo danh mục thành công" });
        }
    }
}