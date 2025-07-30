using Adform_SQL_Task.Models;
using Adform_SQL_Task.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Adform_SQL_Task.Controllers
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
        public IActionResult GetOrderInvoice(int orderId, int productPage = 0, int productPageSize = 0)
        {
            OrderInvoice orderInvoice = _ordersService.GetOrderInvoice(orderId, productPage, productPageSize);
            if (orderInvoice.OrderName == string.Empty)
            {
                string message = "Order with ID: " + orderId + " not found";
                Log.Information(message);
                return NotFound(message);
            }
            if (orderInvoice.OrderProducts.Count == 0)
            {
                string message = "Order with ID: " + orderId + " has no products";
                Log.Information(message);
                return NotFound(message);
            }
            return (Ok(new
            {
                OrderInvoice = orderInvoice
            }));
        }
        [HttpGet]
        [Route("OrderDistributionByCity")]
        public IActionResult GetOrderDistributionByCity(bool order, string city = "", int page = 0, int pageSize = 0)
        {
            List<OrderDistributionByCity> orderDistributions = _ordersService.GetOrderDistributionByCity(city, order, page, pageSize);
            if (orderDistributions.Count == 0 && city != "")
            {
                string message = "City: " + city + " not found";
                Log.Information(message);
                return NotFound("City: " + city + " not found");
            }
            if (orderDistributions.Count == 0)
            {
                string message = "No city resident has made an order";
                Log.Information(message);
                return NotFound(message);
            }
            return (Ok(new
            {
                OrderDistributions = orderDistributions
            }));
        }
    }
}
