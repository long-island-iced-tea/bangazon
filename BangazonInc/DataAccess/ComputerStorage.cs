﻿using BangazonInc.Models;
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

        // Post new Computer

        public bool PostComputer (Computer computer)
        {
            using(var db= _db.GetConnection())
            {
                var sql = db.Execute(@"INSERT INTO [dbo].[Computers]
                                       ([purchasedAt]
                                       ,[decommissionedAt]
                                       ,[isNew]
                                       ,[isWorking])
                                 VALUES
                                       (@purchasedAt
                                       ,@decommissionedAt
                                       ,@isNew
                                       ,@isWorking)", computer);
                return sql == 1;
            }
        }

    }
}