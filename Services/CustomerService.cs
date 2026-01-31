using ASM_Bai2.DTOs;
using ASM_Bai2.Models;
using ASM_Bai2.Repositories.Interfaces;
using ASM_Bai2.Services.Interfaces;
using AutoMapper;
using System.Collections.Generic;

namespace ASM_Bai2.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenericRepository<Customer> _repo;
        private readonly IMapper _mapper;

        public CustomerService(IGenericRepository<Customer> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public List<CustomerDto> GetAll()
        {
            var list = _repo.GetAll();
            return _mapper.Map<List<CustomerDto>>(list);
        }

        public void Create(CreateCustomerDto dto)
        {
            var entity = _mapper.Map<Customer>(dto);
            _repo.Add(entity);
            _repo.Save();
        }
    }
}