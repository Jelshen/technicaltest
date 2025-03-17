using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesOrder.Data;

namespace SalesOrder.Controllers
{
    public class SalesOrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesOrderController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet] // Ensure it accepts GET requests
        public IActionResult AddNewData(int? soOrderId)
        {
            if (soOrderId.HasValue)
            {
                var order = _context.SOOrders.FirstOrDefault(o => o.SOOrderId == soOrderId);
                if (order == null)
                {
                    return NotFound(); // Ensure NotFound() is handled correctly
                }
                return View("SalesOrderItems", order);
            }

            return View("SalesOrderItems"); // Open blank form for new entry
        }

    }
}
