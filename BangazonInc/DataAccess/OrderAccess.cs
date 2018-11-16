﻿using System;
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

        public List<Order> GetAllOrders(bool? completed, string _include)
        {
            using (var sql = _db.GetConnection())
            {
                var command = "SELECT * FROM Orders";

                switch (completed)
                {
                    case true:
                        command += " WHERE completed = 1";
                        break;
                    case false:
                        command += " WHERE completed = 0";
                        break;
                }

                var results = sql.Query<Order>(command).ToList();

                if (_include == "customers")
                {
                    var customers = sql.Query<Customer>("SELECT * FROM Customers");
                    results = results
                        .Select(currentOrder => new OrderWithCustomer(currentOrder, customers.FirstOrDefault(x => x.Id == currentOrder.CustomerId)) as Order)
                        .ToList();
                }

                return results;
            }
        }

        public Order GetSingleOrder(int id, string _include)
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
                var command = @"
DECLARE @inserted TABLE (Id int, CustomerId int, paymentType int, completed bit, isActive bit);

INSERT INTO Orders (CustomerId, paymentType, completed, isActive) 
OUTPUT INSERTED.Id, INSERTED.CustomerId, INSERTED.paymentType, INSERTED.completed, INSERTED.isActive
INTO @inserted

VALUES (@CustomerId, @PaymentType, @Completed, @IsActive)

SELECT * FROM @inserted";

                return sql.QueryFirstOrDefault<Order>(command, newOrder);
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

        public Order ModifyOrder (Order newOrder)
        {
            using (var sql = _db.GetConnection())
            {
                var command = @"
UPDATE Orders
SET CustomerId = @CustomerId, paymentType = @PaymentType, completed = @Completed, isActive = @IsActive
WHERE Id = @Id

SELECT * FROM Orders WHERE Id = @Id";

                return sql.QueryFirstOrDefault<Order>(command, newOrder);
            }
        }
    }
}
