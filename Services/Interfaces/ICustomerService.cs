using ASM_Bai2.DTOs;
using System.Collections.Generic;

namespace ASM_Bai2.Services.Interfaces
{
    public interface ICustomerService
    {
        List<CustomerDto> GetAll();
        void Create(CreateCustomerDto dto);
    }
}