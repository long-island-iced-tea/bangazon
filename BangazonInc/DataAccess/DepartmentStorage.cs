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

        public DepartmentStorage(DatabaseInterface db)
        {
            _db = db;
        }

        // Get All Departments

        public List<Department> GetDept()
        {
            using (var db = _db.GetConnection())
            {
                string sql = "Select * from Department";
                return db.Query<Department>(sql).ToList();
            }
        }

        // Get Single Department

        public Department GetDeptById(int DeptId)
        {
            using (var db = _db.GetConnection())
            {
                var sql = db.QueryFirstOrDefault<Department>(@"Select * from Department Where Id =@id", new { id = DeptId });
                return sql;

            }

        }

        public List<DepartmentWithEmployees> GetWithEmployees()
        {
            var depts = GetDept();
            var deptResponse = new List<DepartmentWithEmployees>();

            using (var db = _db.GetConnection())
            {
                string sql = "SELECT * FROM Employees";
                var employees = db.Query<Employee>(sql);

                foreach(var dept in depts)
                {
                    var deptWithEmployees = new DepartmentWithEmployees(dept);
                    var employeesInDept = employees.Where(e => e.DepartmentId == dept.Id).ToList();
                    deptWithEmployees.Employees = employeesInDept;
                    deptResponse.Add(deptWithEmployees);
                }

                return deptResponse;
            }
        }

        // Posting Department

        public bool AddNew(Department department)
        {
            using (var db = _db.GetConnection())
            {
                string sql = "INSERT INTO Department VALUES (@Name, @Budget, @SupervisorId)";
                var result = db.Execute(sql, department);
                return result == 1;

            }
        }

        // Updating Department

        public bool Edit(Department department)
        {
            using (var db = _db.GetConnection())
            {
                string sql = @"UPDATE Department
                                SET Name = @name,
                                Budget = @budget,
                                SupervisorId = @supervisorId
                            WHERE Id = @id";
                var result = db.Execute(sql, department);
                return result == 1;
            }
        }
    }
}
  
