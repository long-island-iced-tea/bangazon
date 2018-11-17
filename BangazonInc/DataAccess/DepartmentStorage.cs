using BangazonInc.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonInc.DataAccess
{
    public class DepartmentStorage
    {
        DatabaseInterface _db;

        public DepartmentStorage (DatabaseInterface db)
        {
            _db = db;
        }

        // Get All Departments

        public List<Department> GetDept()
        {
          using(var db = _db.GetConnection())
            {
                string sql = "Select * from Department";
                return db.Query<Department>(sql).ToList();
            }
        }
    }
}
