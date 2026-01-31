using ASM_Bai2.DBContext;
using ASM_Bai2.Models;
using ASM_Bai2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASM_Bai2.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public List<Product> GetProductsByCategorySP(int categoryId)
        {
            return _context.Products
                .FromSqlInterpolated($"EXEC sp_GetProductsByCategory @CategoryId={categoryId}")
                .ToList(); // Đồng bộ
        }
    }
}