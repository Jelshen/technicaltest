using SalesOrder.Models;

namespace SalesOrder.Services.Interfaces
{
    public interface ISalesOrderItemsService
    {
        Task<List<SOItem>> GetSalesOrderItemsAsync(long soOrderId);
        Task<SOItem> CreateSalesOrderItemsAsync(SOItem item);
    }
}
