using ASM_Bai2.DTOs;
using System.Collections.Generic;

namespace ASM_Bai2.Services.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryDto> GetAll();
        void Create(CategoryDto dto);
    }
}