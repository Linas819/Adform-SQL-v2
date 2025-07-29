namespace AdForm_SQL_Task.Models
{
    public class OrderInvoice
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; } = string.Empty;
        public float TotalPrice { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
    }
}
