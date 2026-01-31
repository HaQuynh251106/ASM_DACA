using ASM_Bai2.DTOs;
using System.Collections.Generic;

namespace ASM_Bai2.Services.Interfaces
{
    public interface IProductService
    {
        // Service trả về DTO (để Controller dùng luôn), không trả về Entity
        List<ProductDto> GetAllProducts();
        ProductDto GetProductById(int id);
        void CreateProduct(CreateProductDto createDto);
        List<ProductDto> GetProductsByCategory(int categoryId);
    }
}