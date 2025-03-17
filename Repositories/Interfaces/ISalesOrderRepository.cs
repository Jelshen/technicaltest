using SalesOrder.Models;

namespace SalesOrder.Repositories.Interfaces
{
    public interface ISalesOrderRepository
    {
        Task<List<SOOrder>> GetOrdersAsync();
        Task<SOOrder> GetOrderByNameAsync(string soOrderName);
        Task<SOOrder> CreateOrderAsync(SOOrder soOrder);
    }
}
