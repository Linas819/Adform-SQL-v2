using AdForm_SQL_Task.Repositories;

namespace AdForm_SQL_Task.Services
{
    public class OrdersService
    {
        private OrdersRepository _repository;
        public OrdersService(OrdersRepository ordersRepository) 
        {
            _repository = ordersRepository;
        }
        public void GetOrderInvoice(string orderId)
        { 
        }
        public void GetOrderDistribution(string city, bool order)
        { 
        }
    }
}
