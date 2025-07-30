using AdForm_SQL_Task.Models;
using AdForm_SQL_Task.Repositories;

namespace AdForm_SQL_Task.Services
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
            if (orderInvoice.OrderName == string.Empty)
                return orderInvoice;
            orderInvoice.OrderProducts = _repository.GetOrderProducts(orderId);
            foreach (OrderProduct product in orderInvoice.OrderProducts)
            {
                orderInvoice.TotalPrice += product.ProductPrice * product.ProductQautntiy;
            }
            return orderInvoice;
        }
        public List<OrderDistributionByCity> GetOrderDistributionByCity(string city, bool order)
        {
            return _repository.GetOrderDistributionByCity(city, order);
        }
    }
}
