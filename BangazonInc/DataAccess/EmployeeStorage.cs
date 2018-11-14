using BangazonInc.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonInc.DataAccess
{
    public class EmployeeStorage
    {
        DatabaseInterface _db;

        public EmployeeStorage(DatabaseInterface db)
        {
            _db = db;
        }

        /******************************
         Get All Employees
         ******************************/
        public List<Employees> GetAllEmployees()
        {
            using (var db = _db.GetConnection())
            {
                string sql = "SELECT * FROM Employees";
                return db.Query<Employees>(sql).ToList();
            }

        }
    }
}
