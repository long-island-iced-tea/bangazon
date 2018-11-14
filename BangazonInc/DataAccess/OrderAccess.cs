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

        public Order AddNewOrder(Order newOrder)
        {
            using (var sql = _db.GetConnection())
            {
                var paramObject = new
                {
                    CustomerId = newOrder.CustomerId,
                    PaymentType = newOrder.PaymentType,
                    Completed = newOrder.Completed,
                    isActive = newOrder.IsActive
                };

                var command = @"
DECLARE @inserted TABLE (Id int, CustomerId int, paymentType int, completed bit, isActive bit);

INSERT INTO Orders (CustomerId, paymentType, completed, isActive) 
OUTPUT INSERTED.Id, INSERTED.CustomerId, INSERTED.paymentType, INSERTED.completed, INSERTED.isActive
INTO @inserted

VALUES (@CustomerId, @PaymentType, @Completed, @IsActive)

SELECT * FROM @inserted";

                return sql.QueryFirstOrDefault<Order>(command, paramObject);
            }
        }

        public int DeleteOrder (int orderId)
        {
            using (var sql = _db.GetConnection())
            {
                var paramObject = new { @IdToDelete = orderId };

                var command = "DELETE FROM Orders WHERE Id = @IdToDelete";

                return sql.Execute(command, paramObject);
            }
        }
    }
}
