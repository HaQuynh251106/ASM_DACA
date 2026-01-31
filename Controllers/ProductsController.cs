using ASM_Bai2.DTOs;
using ASM_Bai2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ASM_Bai2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetAllProducts());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // API này gọi xuống Service -> Repository -> Chạy Stored Procedure
        [HttpGet("category/{categoryId}")]
        public IActionResult GetByCategory(int categoryId)
        {
            return Ok(_productService.GetProductsByCategory(categoryId));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateProductDto dto)
        {
            try
            {
                _productService.CreateProduct(dto);
                return Ok(new { Message = "Tạo sản phẩm thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}