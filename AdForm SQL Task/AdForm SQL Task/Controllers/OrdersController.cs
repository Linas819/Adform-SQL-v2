using AdForm_SQL_Task.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdForm_SQL_Task.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private OrdersService _ordersService;
        OrdersController(OrdersService ordersService) 
        {
            _ordersService = ordersService;
        }
        [HttpGet]
        public IActionResult GetOrderInvoice(string orderId)
        {
            return View();
        }
    }
}
