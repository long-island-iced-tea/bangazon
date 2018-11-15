using BangazonInc.Models;
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
            _productTypes = new List<ProductType>();
        }
    }
}
