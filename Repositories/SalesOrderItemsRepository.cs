using Microsoft.EntityFrameworkCore;
using SalesOrder.Data;
using SalesOrder.Models;
using SalesOrder.Repositories.Interfaces;

namespace SalesOrder.Repositories
{
    public class SalesOrderItemsRepository : ISalesOrderItemsRepository
    {
        private readonly ApplicationDbContext _context;

        public SalesOrderItemsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SOItem>> GetSalesOrderItemsAsync(long soOrderId)
        {
            var items = await _context.SOItems
                              .Where(item => item.SOOrderId == soOrderId)
                              .ToListAsync();

            if (items == null || !items.Any())
            {
                return new List<SOItem>(); // Returns an empty array []
            }

            return items;
        }

        public async Task<SOItem> CreateSalesOrderItemsAsync(SOItem item)
        {
            _context.SOItems.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

    }
}
