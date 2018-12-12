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
                string sql = @"SELECT 
                                 e.*,
                                 d.name as DepartmentName
                               FROM Employees e
                               JOIN Department d
                                 ON e.departmentId = d.id";
                var employees = db.Query<Employee>(sql).ToList();
                foreach (var employee in employees)
                {
                    var compSQL = db.QueryFirstOrDefault<Computer>(@"Select * from Computers where id = @id", new {id = employee.ComputerId});
                    employee.Computer = compSQL;
                }
                return employees;
            }
        }

        /******************************
           Get Single Employee
         ******************************/
        public Employee GetById(int employeeId)
        {
            using (var db = _db.GetConnection())
            {
                var result = db.QueryFirst<Employee>(@"
                               SELECT 
                                 e.id,
                                 e.ComputerId,
                                 e.firstName,
                                 e.lastName,
                                 d.name AS DepartmentName
                               FROM Employees e
                               JOIN Department d
                                 ON e.departmentId = d.id
                               WHERE e.Id = @id", new { id = employeeId });
                var empComputer = db.QueryFirst<Computer>(@"Select * from Computers where id = @id", new {id = result.ComputerId});
                
                result.Computer = empComputer as Computer;

                return result;
            }
        }

        /******************************
           Update Employee
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