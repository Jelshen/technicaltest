using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesOrder.Data;
using SalesOrder.Models;
using SalesOrder.Services.Interfaces;

namespace SalesOrderItems.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderItemsController : ControllerBase
    {
        private readonly IComCustomerService _comCustomerService;
        private readonly ISalesOrderItemsService _salesOrderItemsService;

        public SalesOrderItemsController(ISalesOrderItemsService salesOrderItemsService, IComCustomerService comCustomerService)
        {
            _comCustomerService = comCustomerService;
            _salesOrderItemsService = salesOrderItemsService;
        }

        [HttpGet("GetSoOrder")]
        public async Task<IActionResult> GetSoOrder([FromQuery] long soOrderId)
        {
            var salesOrderItems = await _salesOrderItemsService.GetSalesOrderItemsAsync(soOrderId);

            return Ok(new { data = salesOrderItems });
        }

        [HttpGet("GetCustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _comCustomerService.GetCustomersAsync();

            var customerList = customers.Select(c => new
            {
                Id = c.ComCustomerId,
                Name = c.CustomerName
            }).ToList();

            return Ok(customerList);

        }
    }
}
