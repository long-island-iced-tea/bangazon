using BangazonInc.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonInc.DataAccess
{
    public class PaymentTypeStorage
    {
        DatabaseInterface _db;

        public PaymentTypeStorage(DatabaseInterface db)
        {
            _db = db;
        }

        public List<PaymentType> GetPaymentTypes()
        {
            using (var db = _db.GetConnection())
            {
                string sql = "SELECT * FROM PaymentType";
                return db.Query<PaymentType>(sql).ToList();
            }

        }
    }
}
