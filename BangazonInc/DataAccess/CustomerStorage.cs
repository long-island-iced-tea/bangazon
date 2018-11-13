﻿using BangazonInc.Models;
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
            var customersWithProducts = new List<CustomerWithProducts>();

            using (var db = _db.GetConnection())
            {
                string sql = @"
                            SELECT *
                            FROM Products
                            WHERE CustomerId = @id";
                var customers = GetCustomers();
                foreach (var customer in customers)
                {
                    var custWithProducts = new CustomerWithProducts(customer);
                    var products = db.Query<Product>(sql, new { id = customer.Id }).ToList();
                    custWithProducts.Products = products;
                    customersWithProducts.Add(custWithProducts);
                }

                return customersWithProducts;
                
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

        public List<CustomerWithPayments> GetCustomersWithPayments()
        {
            var customersWithPayments = new List<CustomerWithPayments>();

            using (var db = _db.GetConnection())
            {
                string sql = @"
                            SELECT *
                            FROM PaymentType
                            WHERE CustomerId = @id";
                var customers = GetCustomers();
                foreach (var customer in customers)
                {
                    var custWithPayments = new CustomerWithPayments(customer);
                    var payments = db.Query<PaymentType>(sql, new { id = customer.Id }).ToList();
                    custWithPayments.Payments = payments;
                    customersWithPayments.Add(custWithPayments);
                }

                return customersWithPayments;
                
            }
        }
    }
}
