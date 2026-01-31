using ASM_Bai2.DTOs;
using ASM_Bai2.Models;
using ASM_Bai2.Repositories.Interfaces;
using ASM_Bai2.Services.Interfaces;
using AutoMapper;
using System.Collections.Generic;

namespace ASM_Bai2.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public void CreateProduct(CreateProductDto createDto)
        {
            // 1. Dùng AutoMapper chuyển từ DTO sang Entity
            var productEntity = _mapper.Map<Product>(createDto);

            // 2. Gọi Repository thêm vào
            _productRepo.Add(productEntity);

            // 3. Gọi Save để lưu xuống DB (Quan trọng với code đồng bộ)
            _productRepo.Save();
        }

        public List<ProductDto> GetAllProducts()
        {
            // Lấy Entity từ Repo
            var products = _productRepo.GetAll();
            // Map sang DTO
            return _mapper.Map<List<ProductDto>>(products);
        }

        public ProductDto GetProductById(int id)
        {
            var product = _productRepo.GetById(id);
            return _mapper.Map<ProductDto>(product);
        }

        public List<ProductDto> GetProductsByCategory(int categoryId)
        {
            // Gọi hàm SP trong Repository
            var products = _productRepo.GetProductsByCategorySP(categoryId);
            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}