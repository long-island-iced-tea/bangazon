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

        /******************************
         Get All Payment Types
         ******************************/
        public List<PaymentType> GetAllPaymentTypes()
        {
            using (var db = _db.GetConnection())
            {
                string sql = "SELECT * FROM PaymentType";
                return db.Query<PaymentType>(sql).ToList();
            }

        }

        /******************************
         Get Single Payment Type by Id
         ******************************/
        public PaymentType GetById(int paymentTypeId)
        {
            using (var db = _db.GetConnection())
            {
                var result = db.QueryFirst<PaymentType>(@"select * 
                                                          from PaymentType
                                                          where Id = @id", new { id = paymentTypeId });
                return result;
            }
        }

        /******************************
         Delete Payment Type by Id
         ******************************/
        public bool DeleteById(int paymentTypeId)
        {
            using (var db = _db.GetConnection())
            {
                var result = db.Execute(@"Delete 
                                          From PaymentType 
                                          Where id = @id", new { id = paymentTypeId });
                return result == 1;
            }
        }

        /******************************
         Add Payment Type to Table
         ******************************/
        public bool Add(PaymentType paymentType)
        {
            using (var db = _db.GetConnection())
            {
                var result = db.Execute(@"INSERT INTO [dbo].[PaymentType]([customerId],[accountNum],[type])
                                          Values (@customerId, @accountNum, @type)", paymentType);
                return result == 1;
            }
        }
    }
}
