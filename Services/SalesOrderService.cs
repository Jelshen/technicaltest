using SalesOrder.Models;
using Microsoft.EntityFrameworkCore;
using SalesOrder.Data;
using SalesOrder.Services.Interfaces;
using SalesOrder.Repositories.Interfaces;

namespace SalesOrder.Services
{
    public class SalesOrderService : ISalesOrderService
    {
        private readonly ISalesOrderRepository _salesOrderRepository;

        public SalesOrderService(ISalesOrderRepository salesOrderRepository)
        {
            _salesOrderRepository = salesOrderRepository;
        }

        public async Task<List<SOOrder>> GetOrdersAsync()
        {
            return await _salesOrderRepository.GetOrdersAsync();
        }

        public async Task<SOOrder> GetOrderByNameAsync(string soOrderName)
        {
            return await _salesOrderRepository.GetOrderByNameAsync(soOrderName);
        }

        public async Task<SOOrder> CreateOrderAsync(SOOrder order)
        {
            return await _salesOrderRepository.CreateOrderAsync(order);
        }
    }
}
