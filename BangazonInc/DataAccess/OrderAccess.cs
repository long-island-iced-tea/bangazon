using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using BangazonInc.Models;


namespace BangazonInc.DataAccess
{
    public class OrderAccess
    {
        private DatabaseInterface _db;

        public OrderAccess (DatabaseInterface db)
        {
            _db = db;
        }

        public List<Order> GetAllOrders()
        {
            using (var sql = _db.GetConnection())
            {
                return sql.Query<Order>("SELECT * FROM Orders").ToList();
            }
        }

        public Order GetSingleOrder(int id)
        {
            using (var sql = _db.GetConnection())
            {
                var param = new { orderId = id };
                return sql.QueryFirstOrDefault<Order>("SELECT * FROM Orders WHERE Id = @orderId", param);
            }
        }
    }
}
