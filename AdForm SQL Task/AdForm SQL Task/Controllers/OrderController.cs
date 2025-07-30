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
            else if (orderInvoice.OrderProducts.Count == 0)
                return NotFound("Order with ID: " + orderId + " has no products");
            return (Ok(new
            {
                OrderInvoice = orderInvoice
            }));
        }
        [HttpGet]
        [Route("OrderDistributionByCity")]
        public IActionResult GetOrderDistributionByCity(bool order, string city = "")
        {
            List<OrderDistributionByCity> orderDistributions = _ordersService.GetOrderDistributionByCity(city, order);
            if (orderDistributions.Count == 0 && city != "")
                return NotFound("City: " + city + " not found");
            else if (orderDistributions.Count == 0)
                return NotFound("No city resident has made an order");
            return (Ok(new
            {
                OrderDistributions = orderDistributions
            }));
        }
    }
}
