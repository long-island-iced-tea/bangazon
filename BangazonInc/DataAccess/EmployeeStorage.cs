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
        public List<Employee> GetAllEmployees()
        {
            using (var db = _db.GetConnection())
            {
                string sql = "SELECT * FROM Employees";
                return db.Query<Employee>(sql).ToList();
            }
        }

        /******************************
           Get Single Employee
         ******************************/
        public Employee GetById(int employeeId)
        {
            using (var db = _db.GetConnection())
            {
                var result = db.QueryFirst<Employee>(@"select * 
                                                          from Employees
                                                          where Id = @id", new { id = employeeId });
                return result;
            }
        }

        /******************************
           Update Payment Type
         ******************************/
        public bool Put(Employee employee)
        {
            using (var db = _db.GetConnection())
            {
                var result = db.Execute(@"Update Employees
                                          Set firstName = @firstName,
                                              lastName = @lastName,
                                              departmentId = @departmentId,
                                              computerId = @computerId
                                          Where id = @id", employee);
                return result == 1;
            }
        }

        /******************************
          Add an Employee to Table
        ******************************/
        public bool Add(Employee employee)
        {
            using (var db = _db.GetConnection())
            {
                var result = db.Execute(@"INSERT INTO [dbo].[Employees]([firstName],[lastName],[departmentId], [computerId])
                                          Values (@firstName, @lastName, @departmentId, @computerId)", employee);

                return result == 1;
            }
        }
    }
}
