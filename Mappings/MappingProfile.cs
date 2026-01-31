using AutoMapper;
using ASM_Bai2.Models;
using ASM_Bai2.DTOs;

namespace ASM_Bai2
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Product & Order (Đã có)
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName));
            CreateMap<CreateProductDto, Product>();
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FullName));

            // --- THÊM MỚI ---
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<CreateCustomerDto, Customer>();
        }
    }
}