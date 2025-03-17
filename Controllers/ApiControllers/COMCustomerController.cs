using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesOrder.Services.Interfaces;

namespace SalesOrder.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class COMCustomerController : ControllerBase
    {
        private readonly IComCustomerService _comCustomerService;

        public COMCustomerController(IComCustomerService comCustomerService)
        {
            _comCustomerService = comCustomerService;
        }

        // Get all sales orders
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _comCustomerService.GetCustomersAsync();
            return Ok(orders);
        }
    }
}
