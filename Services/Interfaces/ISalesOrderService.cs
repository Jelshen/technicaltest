using SalesOrder.Models;

namespace SalesOrder.Services.Interfaces
{
    public interface ISalesOrderService
    {
        Task<List<SOOrder>> GetOrdersAsync();
        Task<SOOrder> GetOrderByNameAsync(string soOrderName);
        Task<SOOrder> CreateOrderAsync(SOOrder soOrder);
    }
}
