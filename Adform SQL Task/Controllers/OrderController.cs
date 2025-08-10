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
        /// <summary>
        /// Get the invoice details for a specific order. Can return product list by pages if they have been set.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /order
        ///     {
        ///         "orderId": "11001"
        ///     }
        /// </remarks>
        /// <param name="orderId"></param>
        /// <response code="404">Order with the Id not found / Order has no products</response>
        /// <returns>Order name, list of products, total price of the order</returns>
        [HttpGet]
        public IActionResult GetOrderInvoice(int orderId)
        {
            OrderInvoice orderInvoice = _ordersService.GetOrderInvoice(orderId);
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
        /// <summary>
        /// Get order distribution by city or cities. Can be orderd as well. Can also return product list by pages if they have been set.
        /// </summary>
        /// <remarks>
        /// Sample request (specific city, no pagination):
        /// 
        ///     GET /Order/OrderDistributionByCity
        ///     {
        ///         "order": false,
        ///         "city": "West Jalon"
        ///     }
        /// Sample request (all cities, ordered with pagination):
        /// 
        ///     GET /Order/OrderDistributionByCity
        ///     {
        ///         "order": true,
        ///         "city": "",
        ///         "page": 1
        ///         "pageSize": 10
        ///     }
        /// </remarks>
        /// <param name="order"></param>
        /// <param name="city"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <response code="404">City not found / No city resident has made an order</response>
        /// <response code="400">Page size and selected page cannot be lower than 0</response>
        /// <returns>Order name, list of products, total price of the order</returns>
        [HttpGet]
        [Route("OrderDistributionByCity")]
        public IActionResult GetOrderDistributionByCity(bool order, string city = "", int page = 0, int pageSize = 0)
        {
            if (page < 0 || pageSize < 0)
            {
                string message = "Page size and selected page cannot be lower than 0";
                Log.Error(message);
                return BadRequest(message);
            }
            if ((page == 0 && pageSize != 0) || (page != 0 && pageSize == 0))
            {
                string message = "Both page and page size must be positive values";
                Log.Error(message);
                return BadRequest(message);
            }
            List<OrderDistributionByCity> orderDistributions = _ordersService.GetOrderDistributionByCity(city, order, page, pageSize);
            if (orderDistributions.Count == 0 && city != "")
            {
                string message = "City: " + city + " not found";
                Log.Information(message);
                return NotFound(message);
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
