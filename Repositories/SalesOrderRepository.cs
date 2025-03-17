using SalesOrder.Models;
using Microsoft.EntityFrameworkCore;
using SalesOrder.Data;
using SalesOrder.Repositories.Interfaces;

namespace SalesOrder.Repositories
{
    public class SalesOrderRepository : ISalesOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public SalesOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SOOrder>> GetOrdersAsync()
        {
            return await _context.SOOrders.ToListAsync();
        }

        public async Task<SOOrder> GetOrderByNameAsync(string soOrderName)
        {
            var items = await _context.SOOrders
                              .Where(item => item.OrderNo == soOrderName)
                              .FirstOrDefaultAsync();

            return items;
        }

        public async Task<SOOrder> CreateOrderAsync(SOOrder order)
        {
            _context.SOOrders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
