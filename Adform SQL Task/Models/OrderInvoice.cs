namespace Adform_SQL_Task.Models
{
    public class OrderInvoice
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; } = string.Empty;
        public double TotalPrice { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
    }
}
