using SalesOrder.Models;

namespace SalesOrder.Repositories.Interfaces
{
    public interface ISalesOrderItemsRepository
    {
        Task<List<SOItem>> GetSalesOrderItemsAsync(long soOrderId);
        Task<SOItem> CreateSalesOrderItemsAsync(SOItem item);
    }
}
