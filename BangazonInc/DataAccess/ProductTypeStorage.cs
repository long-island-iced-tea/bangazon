using BangazonInc.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonInc.DataAccess
{
    public class ProductTypeStorage
    {
        DatabaseInterface _db;
        static List<ProductType> _productTypes;

        public ProductTypeStorage(DatabaseInterface db)
        {
            _db = db;
            _productTypes = LoadProductTypes();
        }

        private List<ProductType> LoadProductTypes()
        {
            using (var db = _db.GetConnection())
            {
                string sql = "SELECT * FROM ProductTypes";
                return db.Query<ProductType>(sql).ToList();
            }
        }

        public List<ProductType> GetProductTypes()
        {
            return _productTypes;
        }

        public ProductType GetById(int id)
        {
            return _productTypes.FirstOrDefault(pt => pt.Id == id);
        }
    }
}
