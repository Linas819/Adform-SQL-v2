using System.Data.Common;

namespace AdForm_SQL_Task.Repositories
{
    public class OrdersRepository
    {
        private string connString;
        public OrdersRepository(IConfiguration configuration) 
        {
            connString = configuration.GetConnectionString("LocalDatabase")??"";
        }
    }
}
