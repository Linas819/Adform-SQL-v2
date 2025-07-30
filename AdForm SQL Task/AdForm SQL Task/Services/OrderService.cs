using Adform_SQL_Task.Models;
using Adform_SQL_Task.Repositories;

namespace Adform_SQL_Task.Services
{
    public class OrderService
    {
        private OrderRepository _repository;
        public OrderService(OrderRepository ordersRepository) 
        {
            _repository = ordersRepository;
        }
        public OrderInvoice GetOrderInvoice(int orderId, int productPage, int productPageSize)
        { 
            OrderInvoice orderInvoice = new OrderInvoice();
            orderInvoice.OrderId = Convert.ToInt32(orderId);
            orderInvoice.OrderName = _repository.GetOrderName(orderId);
            if (orderInvoice.OrderName == string.Empty) // If ordername is not found, that means that no order exists
                return orderInvoice;
            orderInvoice.OrderProducts = _repository.GetOrderProducts(orderId);
            foreach (OrderProduct product in orderInvoice.OrderProducts)
            {
                orderInvoice.TotalPrice += product.ProductPrice * product.ProductQautntiy;
            }
            if (productPage != 0 && orderInvoice.OrderProducts.Count > 0)
            {
                int orderProductsCount = orderInvoice.OrderProducts.Count;
                int totalPages = (int)Math.Ceiling((decimal)orderProductsCount / productPageSize);
                orderInvoice.OrderProducts = orderInvoice.OrderProducts
                    .Skip((productPage-1) *productPageSize)
                    .Take(productPageSize)
                    .ToList();
            }
            return orderInvoice;
        }
        public List<OrderDistributionByCity> GetOrderDistributionByCity(string city, bool order, int page, int pageSize)
        {
            List<OrderDistributionByCity> orderDistributions = _repository.GetOrderDistributionByCity(city, order);
            if (page != 0 && orderDistributions.Count > 0)
            {
                int orderDistributionsCount = orderDistributions.Count;
                int totalPages = (int)Math.Ceiling((decimal)orderDistributionsCount / pageSize);
                orderDistributions = orderDistributions
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
            return orderDistributions;
        }
    }
}
