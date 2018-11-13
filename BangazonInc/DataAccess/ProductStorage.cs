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

        public List<Product> GetProduct()
        {
            using(var db= _db.GetConnection())
            {
                string sql = "SELECT * FROM PRODUCT";
                return db.Query<Product>(sql).ToList();
            }
        }
    }
}
