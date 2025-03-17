using SalesOrder.Models;
using SalesOrder.Repositories.Interfaces;
using SalesOrder.Services.Interfaces;

namespace SalesOrder.Services
{
    public class ComCustomerService : IComCustomerService
    {
        private readonly IComCustomerRepository _comCustomerRepository;

        public ComCustomerService(IComCustomerRepository comCustomerRepository)
        {
            _comCustomerRepository = comCustomerRepository;
        }

        public async Task<List<COMCustomer>> GetCustomersAsync()
        {
            return await _comCustomerRepository.GetCustomersAsync();
        }
    }
}
