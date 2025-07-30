using AdForm_SQL_Task.Models;
using Npgsql;

namespace AdForm_SQL_Task.Repositories
{
    public class OrderRepository
    {
        private string connString;
        public OrderRepository(IConfiguration configuration) 
        {
            connString = configuration.GetConnectionString("LocalDatabase") ??"";
        }
        public string GetOrderName(int orderId)
        {
            string name = "";
            string query = "SELECT order_name FROM orders WHERE order_id = " + orderId + ";";
            using (NpgsqlConnection connection = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.Clear();
                    cmd.CommandText = query;
                    connection.Open();
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        name = reader.GetString(0);
                    }
                }
            }
            return name;
        }
        public List<OrderProduct> GetOrderProducts(int orderId)
        {
            List<OrderProduct> orderProducts = new List<OrderProduct>();
            string query = "SELECT * FROM get_order_products("+orderId+")";
            using (NpgsqlConnection connection = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.Clear();
                    cmd.CommandText = query;
                    connection.Open();
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        orderProducts.Add(new OrderProduct()
                        {
                            ProductName = reader["Product name"].ToString(),
                            ProductCategory = reader["Product category"].ToString(),
                            ProductPrice = float.Parse(reader["Product price"].ToString()),
                            ProductQautntiy = Convert.ToInt32(reader["Product quantity"])
                        });
                    }
                }
            }
            return orderProducts;
        }
        public List<OrderDistributionByCity> GetOrderDistributionByCity(string city, bool order)
        {
            List<OrderDistributionByCity> orderDistributions = new List<OrderDistributionByCity>();
            string query = "SELECT * FROM get_orders_by_city('" + city + "', " + order + ")";
            using (NpgsqlConnection connection = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.Clear();
                    cmd.CommandText = query;
                    connection.Open();
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        orderDistributions.Add(new OrderDistributionByCity() 
                        {
                            City = reader["City"].ToString(),
                            OrderCount = Convert.ToInt32(reader["Order count"].ToString())
                        });
                    }
                }
            }
            return orderDistributions;
        }
    }
}
