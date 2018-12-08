using BangazonInc.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonInc.DataAccess
{
    public class ComputerStorage
    {
        DatabaseInterface _db;

        public ComputerStorage(DatabaseInterface db)
        {
            _db = db;
        }

        //Get all Computers

        public List<Computer> GetComputer()
        {
            using (var db = _db.GetConnection())
            {
                string sql = "Select * From Computers";
                return db.Query<Computer>(sql).ToList();
            }
        }

        // Get Single Computer 
        public Computer GetComputerById(int ComputerId)
        {
            using (var db= _db.GetConnection())
            {
                var sql = db.QueryFirstOrDefault<Computer>(@"SELECT * From Computers Where Id = @id", new { id = ComputerId });
                return sql;
            }
        }

        // Delete Single Computer

        public bool DeleteById(int ComputerId)
        {
            using (var db = _db.GetConnection())
            {
                var sql = db.Execute("Delete from Computers Where Id = @id", new { id = ComputerId });
                return sql == 1;
            }
        }

        // Update Computer
        public bool UpdateComputer (Computer computer)
        {
            using (var db = _db.GetConnection())
            {
                var sql = db.Execute(@"UPDATE [dbo].[Computers]

                                       SET [purchasedAt] = @purchasedAt
                                          ,[decommissionedAt] = @decommissionedAt
                                          ,[isNew] = @isNew
                                          ,[isWorking] = @isWorking
                                            Where Id = @id", computer);
                return sql == 1;
            }
        }

        public async Task<ComputerWithEmployeeId> PostComputerAndAssignToEmployee(ComputerWithEmployeeId computer)
        {
            var insertedComputer = new ComputerWithEmployeeId(await PostComputer(computer));
            using (var db = _db.GetConnection())
            {
                var updated = db.Execute(@"UPDATE Employees
                                            SET computerId = @ComputerId
                                            WHERE id = @EmployeeId", new { ComputerId = insertedComputer.Id, computer.EmployeeId });
                if (updated == 1) insertedComputer.EmployeeId = computer.EmployeeId;
                return insertedComputer;
            }
        }

        // Post new Computer

        public async Task<Computer> PostComputer (Computer computer)
        {
            using(var db= _db.GetConnection())
            {
                return await db.QueryFirstOrDefaultAsync<Computer>(@"INSERT INTO [dbo].[Computers]
                                       ([purchasedAt]
                                       ,[decommissionedAt]
                                       ,[isNew]
                                       ,[isWorking])
                                 OUTPUT INSERTED.*
                                 VALUES
                                       (@purchasedAt
                                       ,@decommissionedAt
                                       ,@isNew
                                       ,@isWorking)", computer);
            }
        }

    }
}
