using BangazonInc.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonInc.DataAccess
{
    public class ProductStorage
    {
        DatabaseInterface _db;

        public ProductStorage(DatabaseInterface db)
        {
            _db = db;
        }
        // Get ALL PRODUCTS
        public List<Product> GetProducts()
        {
            using(var db= _db.GetConnection())
            {
                string sql = "SELECT * FROM PRODUCTS";
                return db.Query<Product>(sql).ToList();
            }
        }

        // Get recent PRODUCTS
        public List<UpdatedProduct> GetRecentProducts()
        {
            using (var db = _db.GetConnection())
            {
                string sql = @"select top 20 
                                 prod.Name name,
                                 prod.description description,
                                 prod.price price,
                                 pt.Name category
                               from Products prod
                               join ProductTypes pt 
                                 on prod.productType = pt.id
                               order by prod.id DESC";
                return db.Query<UpdatedProduct>(sql).ToList();
            }
        }

        // GET SINGLE PRODUCT
        public Product GetProductById(int ProductId)
        {
            using (var db = _db.GetConnection())
            {
                var sql = db.QueryFirstOrDefault<Product>(@"SELECT * 
                                                            FROM PRODUCTS WHERE Id = @id", new { id = ProductId});
                return sql;
            }
        }

        // DELETE SINGLE PRODUCT

        public bool DeleteById(int ProductId)
        {
            using (var db = _db.GetConnection())
            {
                var sql = db.Execute("DELETE FROM PRODUCTS WHERE Id = @id", new { id = ProductId });
                return sql == 1;
            }
        }

        // UPDATE PRODUCT

        public bool UpdateProduct(Product product)
        {
            using(var db= _db.GetConnection())
            {
                var sql = db.Execute(@"UPDATE [dbo].[Products]
                                         SET [Name] = @Name
                                          ,[description] = @description 
                                          ,[price] = @price
                                          ,[quantity] = @quantity
                                          ,[customerId] = @customerId
                                          ,[productType] = @productType
                                            WHERE Id = @id", product);
                return sql == 1;
            }
        }

        // POST PRODUCT

        public bool PostProduct (Product product)
        {
            using(var db= _db.GetConnection())
            {
                var sql = db.Execute(@" INSERT INTO [dbo].[Products]
                                           ([Name]
                                           ,[description]
                                           ,[price]
                                           ,[quantity]
                                           ,[customerId]
                                           ,[productType])
                                     VALUES
                                           (@Name
                                           ,@description
                                           ,@price
                                           ,@quantity
                                           ,@customerId
                                           ,@productType)", product);
                return sql == 1;
            }
        }
    }
}
