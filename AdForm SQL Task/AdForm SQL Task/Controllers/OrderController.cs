using AdForm_SQL_Task.Models;
using AdForm_SQL_Task.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdForm_SQL_Task.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private OrderService _ordersService;
        public OrderController(OrderService ordersService) 
        {
            _ordersService = ordersService;
        }
        [HttpGet]
        public IActionResult GetOrderInvoice(int orderId)
        {
            OrderInvoice orderInvoice = _ordersService.GetOrderInvoice(orderId);
            if (orderInvoice.OrderName == string.Empty)
                return NotFound("Order with ID: "+orderId+" not found");
            return (Ok(new
            {
                OrderInvoice = orderInvoice
            }));
        }
    }
}
