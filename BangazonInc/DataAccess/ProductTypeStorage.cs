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

        public ProductType AddNew(ProductType ptype)
        {
            using (var db = _db.GetConnection())
            {
                
                string sql = "INSERT INTO ProductTypes VALUES (@name)";
                var result = db.Execute(sql, ptype);
                ptype.Id = _productTypes.Max(c => c.Id) + 1;
                _productTypes.Add(ptype);
                return ptype;
            }
        }

        public bool Delete(int id)
        {
            using (var db = _db.GetConnection())
            {
                string sql = "DELETE FROM ProductTypes WHERE Id = @id";
                var result = db.Execute(sql, new { id });
                if (result == 1)
                {
                    var typeToRemove = _productTypes.First(pt => pt.Id == id);
                    _productTypes.Remove(typeToRemove);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public ProductType Edit(ProductType ptype)
        {
            using (var db = _db.GetConnection())
            {
                string sql = "UPDATE ProductTypes SET Name = @Name WHERE Id = @Id";
                db.Execute(sql, ptype);
                var editedType = _productTypes.FirstOrDefault(pt => pt.Id == ptype.Id);
                editedType.Name = ptype.Name;
                return ptype;
            }
        }
    }
}
