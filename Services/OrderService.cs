using ASM_Bai2.DTOs;
using ASM_Bai2.Models.StoredProcedureResults;
using ASM_Bai2.Repositories.Interfaces;
using ASM_Bai2.Services.Interfaces;
using AutoMapper;

namespace ASM_Bai2.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }

        public int CreateOrder(int customerId)
        {
            // Gọi thẳng Repository để chạy SP tạo đơn
            return _orderRepo.CreateOrderSP(customerId);
        }

        public List<OrderDto> GetAllOrders()
        {
            var orders = _orderRepo.GetAll();
            return _mapper.Map<List<OrderDto>>(orders);
        }

        public List<OrderDetailResult> GetOrderDetails(int orderId)
        {
            return _orderRepo.GetOrderDetailsSP(orderId);
        }

        public List<OrderWithCustomerResult> GetOrdersWithCustomer()
        {
            return _orderRepo.GetOrdersWithCustomerSP();
        }
    }
}