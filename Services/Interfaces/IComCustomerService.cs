using SalesOrder.Models;

namespace SalesOrder.Services.Interfaces
{
    public interface IComCustomerService
    {
        Task<List<COMCustomer>> GetCustomersAsync();
    }
}
