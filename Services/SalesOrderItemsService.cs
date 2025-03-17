using SalesOrder.Models;
using SalesOrder.Repositories.Interfaces;
using SalesOrder.Services.Interfaces;

namespace SalesOrder.Services
{
    public class SalesOrderItemsService : ISalesOrderItemsService
    {
        private readonly ISalesOrderItemsRepository _salesOrderItemsRepository;

        public SalesOrderItemsService(ISalesOrderItemsRepository salesOrderItemsRepository)
        {
            _salesOrderItemsRepository = salesOrderItemsRepository;
        }

        public async Task<List<SOItem>> GetSalesOrderItemsAsync(long orderId)
        {
            return await _salesOrderItemsRepository.GetSalesOrderItemsAsync(orderId);
        }

        public async Task<SOItem> CreateSalesOrderItemsAsync(SOItem item)
        {
            return await _salesOrderItemsRepository.CreateSalesOrderItemsAsync(item);
        }
    }
}
