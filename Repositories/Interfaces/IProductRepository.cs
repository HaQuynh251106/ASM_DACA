using ASM_Bai2.Models;
using System.Collections.Generic;

namespace ASM_Bai2.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        List<Product> GetProductsByCategorySP(int categoryId);
    }
}