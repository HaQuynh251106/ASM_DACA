using ASM_Bai2.Models;
using ASM_Bai2.Models.StoredProcedureResults;
using System.Collections.Generic;

namespace ASM_Bai2.Repositories.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        List<OrderDetailResult> GetOrderDetailsSP(int orderId);
        List<OrderWithCustomerResult> GetOrdersWithCustomerSP();
        int CreateOrderSP(int customerId);
    }
}