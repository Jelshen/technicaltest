using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesOrder.Models;
using SalesOrder.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using SalesOrder.Services.Interfaces;


namespace SalesOrder.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderController : ControllerBase
    {
        private readonly ISalesOrderService _salesOrderService;

        public SalesOrderController(ISalesOrderService salesOrderService)
        {
            _salesOrderService = salesOrderService;
        }

        // Get all sales orders
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _salesOrderService.GetOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("GetOrderByName")]
        public async Task<IActionResult> GetOrderByName([FromQuery] string soOrderName)
        {
            var order = await _salesOrderService.GetOrderByNameAsync(soOrderName);
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] SOOrder soOrder)
        {
            if (soOrder == null)
            {
                return BadRequest();
            }

            var createdOrder = await _salesOrderService.CreateOrderAsync(soOrder);
            return Ok(createdOrder);
        }
    }
}
