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
        public OrderInvoice GetOrderInvoice(int orderId)
        { 
            OrderInvoice orderInvoice = new OrderInvoice();
            orderInvoice.OrderId = Convert.ToInt32(orderId);
            orderInvoice.OrderName = _repository.GetOrderName(orderId);
            if (orderInvoice.OrderName == string.Empty) // If ordername is not found, that means that no order exists
                return orderInvoice;
            orderInvoice.OrderProducts = _repository.GetOrderProducts(orderId);
            orderInvoice.TotalPrice = _repository.GetOrderTotalPrice(orderId);
            return orderInvoice;
        }
        public List<OrderDistributionByCity> GetOrderDistributionByCity(string city, bool order, int page, int pageSize)
        {
            List<OrderDistributionByCity> orderDistributions = _repository.GetOrderDistributionByCity(city, order, page, pageSize);
            return orderDistributions;
        }
    }
}
