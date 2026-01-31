using ASM_Bai2.DBContext;
using ASM_Bai2.Models;
using ASM_Bai2.Models.StoredProcedureResults;
using ASM_Bai2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASM_Bai2.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        // 1. Lấy chi tiết đơn hàng
        public List<OrderDetailResult> GetOrderDetailsSP(int orderId)
        {
            return _context.OrderDetailResults
                .FromSqlInterpolated($"EXEC sq_GetOrderDetail @OrderId={orderId}")
                .ToList(); // Đồng bộ
        }

        // 2. Lấy đơn hàng kèm khách
        public List<OrderWithCustomerResult> GetOrdersWithCustomerSP()
        {
            return _context.OrderWithCustomerResults
                .FromSqlInterpolated($"EXEC sp_GetOrdersWithCustomer")
                .ToList(); // Đồng bộ
        }

        // 3. Tạo đơn hàng mới
        public int CreateOrderSP(int customerId)
        {
            // Database.SqlQuery cũng hỗ trợ ToList() đồng bộ
            var result = _context.Database
                .SqlQuery<int>($"EXEC sp_InsertOrder @CustomerId={customerId}")
                .ToList();

            return result.FirstOrDefault();
        }
    }
}