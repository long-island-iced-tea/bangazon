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
                    foreach (var order in results)
                    {
                        order.Customer = customers.FirstOrDefault(c => c.Id == order.CustomerId);
                    }
                    
                }
                else if (_include == "products")
                {
                    var products = sql.Query<Product>(@"SELECT 
	                                                        p.*,
	                                                        o.id AS orderId 
                                                        FROM Orders o
                                                        JOIN ProductOrders po ON o.id = po.OrderId 
                                                        JOIN Products p ON p.id = po.ProductId");
                    
                    foreach (var order in results)
                    {
                        order.Products = products.Where(p => p.OrderId == order.Id).ToList();
                    }
                }

                return results;
            }
        }

        public Order GetSingleOrder(int id, string _include)
        {
            using (var sql = _db.GetConnection())
            {
                var param = new { orderId = id };
                var requestedOrder = sql.QueryFirstOrDefault<Order>("SELECT * FROM Orders WHERE Id = @orderId", param);

                if (_include == "customers")
                {
                    var cust = sql.QueryFirstOrDefault<Customer>("SELECT * FROM Customers WHERE Id = @Id", new { Id = requestedOrder.CustomerId });
                    requestedOrder.Customer = cust;
                }
                else if (_include == "products")
                {
                    var products = sql.Query<Product>(@"SELECT 
	                                                        p.*,
	                                                        o.id AS orderId 
                                                        FROM Orders o
                                                        JOIN ProductOrders po ON o.id = po.OrderId 
                                                        JOIN Products p ON p.id = po.ProductId");

                    requestedOrder.Products = products.Where(p => p.OrderId == requestedOrder.Id).ToList();
                }

                return requestedOrder;
            }
        }

        public Order AddNewOrder(Order newOrder)
        {
            using (var sql = _db.GetConnection())
            {
                var command = @"
INSERT INTO Orders (CustomerId, paymentType, completed, isActive) 
OUTPUT INSERTED.*

VALUES (@CustomerId, @PaymentType, @Completed, @IsActive)";

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
