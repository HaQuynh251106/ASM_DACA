using ASM_Bai2.DTOs;
using ASM_Bai2.Models;
using ASM_Bai2.Repositories.Interfaces;
using ASM_Bai2.Services.Interfaces;
using AutoMapper;
using System.Collections.Generic;

namespace ASM_Bai2.Services
{
    public class CategoryService : ICategoryService
    {
        // Gọi thẳng GenericRepository
        private readonly IGenericRepository<Category> _repo;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public List<CategoryDto> GetAll()
        {
            var list = _repo.GetAll();
            return _mapper.Map<List<CategoryDto>>(list);
        }

        public void Create(CategoryDto dto)
        {
            var entity = _mapper.Map<Category>(dto);
            _repo.Add(entity);
            _repo.Save(); // Bắt buộc gọi Save() vì GenericRepo Add chưa lưu
        }
    }
}