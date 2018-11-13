using BangazonInc.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonInc.DataAccess
{
    public class CustomerStorage
    {
        DatabaseInterface _db;

        public CustomerStorage(DatabaseInterface db)
        {
            _db = db;
        }

        public List<Customer> GetCustomers()
        {
            using (var db = _db.GetConnection())
            {
                string sql = "SELECT * FROM Customers";
                return db.Query<Customer>(sql).ToList();
            }
        }

        public Customer GetCustomerById(int? id)
        {
            using (var db = _db.GetConnection())
            {
                string sql = "SELECT * FROM Customers WHERE Id = @id";
                return db.QueryFirstOrDefault<Customer>(sql, new { id });
            }
        }

        public List<CustomerWithProducts> GetCustomersWithProducts()
        {
            using (var db = _db.GetConnection())
            {
                string sql = @"
                            SELECT *
                            FROM Customers c
                                JOIN Products p ON p.CustomerId = c.Id";

                var customers = db.Query<Customer, Product, CustomerWithProducts>(sql,
                    map: (c, p) => {
                        var custWithProducts = new CustomerWithProducts(c);
                        custWithProducts.Products.Add(p);
                        return custWithProducts;
                    },
                    splitOn: "isActive,id");
                return customers.ToList();
            }
        }
    }
}
