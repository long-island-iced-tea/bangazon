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

        public List<Customer> GetCustomersWithProducts()
        {

            using (var db = _db.GetConnection())
            {
                string sql = @"
                            SELECT *
                            FROM Products";

                var customers = GetCustomers();
                var products = db.Query<Product>(sql).ToList();

                foreach (var customer in customers)
                {
                    customer.Products = products.Where(p => p.CustomerId == customer.Id).ToList();
                }

                return customers;
                
            }
        }

        public List<Customer> GetCustomersWithOrders(bool? active)
        {

            string sql = @"SELECT c.* 
                        FROM Customers c
	                        LEFT JOIN Orders o ON c.id = o.CustomerId";

            if (active == true)
            {
                sql += " WHERE o.Id IS NOT NULL";
            }
            else
            {
                sql += " WHERE o.Id IS NULL";
            }

            using (var db = _db.GetConnection())
            {
                return db.Query<Customer>(sql).ToList();
            }

        }

        public bool AddNew(Customer newCustomer)
        {
            using (var db = _db.GetConnection())
            {
                string sql = @"
                            INSERT INTO Customers
                            VALUES (@firstName,
                                    @lastName,
                                    GETDATE(),
                                    1)";
                var result = db.Execute(sql, newCustomer);
                return result == 1;
            }
        }

        public bool UpdateCustomer(Customer newCustomer)
        {
            using (var db = _db.GetConnection())
            {
                string sql = @"
                            UPDATE Customers
                                SET firstName = @firstName,
                                lastName = @lastName,
                                isActive = @isActive
                            WHERE Id = @id";
                var result = db.Execute(sql, newCustomer);
                return result == 1;
            }
        }

        public List<Customer> GetCustomersByTerm(string q)
        {

            return GetCustomers()
                .Where(c => 
                    c.FirstName.ToLower().Contains(q.ToLower()) 
                    || c.LastName.ToLower().Contains(q.ToLower())
                    )
                .ToList();

        }

        public List<Customer> GetCustomersWithPayments()
        {

            using (var db = _db.GetConnection())
            {
                string sql = @"
                            SELECT *
                            FROM PaymentType";

                var customers = GetCustomers();
                var payments = db.Query<PaymentType>(sql).ToList();
                foreach (var customer in customers)
                {
                    customer.Payments = payments.Where(p => p.CustomerId == customer.Id).ToList();
                }

                return customers;
                
            }
        }
    }
}
