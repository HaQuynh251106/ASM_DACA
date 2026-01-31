using ASM_Bai2.DTOs;
using ASM_Bai2.Models.StoredProcedureResults;
using System.Collections.Generic;

namespace ASM_Bai2.Services.Interfaces
{
    public interface IOrderService
    {
        // 1. Lấy tất cả đơn hàng (Map sang DTO)
        List<OrderDto> GetAllOrders();

        // 2. Các hàm gọi SP (Vì Result Class đã giống DTO rồi nên trả về luôn cũng được)
        List<OrderDetailResult> GetOrderDetails(int orderId);
        List<OrderWithCustomerResult> GetOrdersWithCustomer();

        // 3. Tạo đơn hàng
        int CreateOrder(int customerId);
    }
}