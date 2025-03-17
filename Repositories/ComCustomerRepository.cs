using SalesOrder.Data;
using Microsoft.EntityFrameworkCore;
using SalesOrder.Models;
using SalesOrder.Repositories.Interfaces;

namespace SalesOrder.Repositories
{
    public class ComCustomerRepository : IComCustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public ComCustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<COMCustomer>> GetCustomersAsync()
        {
            return await _context.COMCustomers.ToListAsync();
        }
    }
}
