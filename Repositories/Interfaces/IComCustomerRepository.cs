using SalesOrder.Models;

namespace SalesOrder.Repositories.Interfaces
{
    public interface IComCustomerRepository
    {
        Task<List<COMCustomer>> GetCustomersAsync();
    }
}
