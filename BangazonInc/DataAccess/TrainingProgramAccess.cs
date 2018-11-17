using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangazonInc.Models;
using Dapper;

namespace BangazonInc.DataAccess
{
    public class TrainingProgramAccess
    {
        private DatabaseInterface _db;

        public TrainingProgramAccess (DatabaseInterface db)
        {
            _db = db;
        }

        public List<TrainingProgram> GetAllPrograms(bool? completed)
        {
            using (var sql = _db.GetConnection())
            {
                var command = "SELECT * FROM TrainingProgram";

                switch (completed)
                {
                    case true:
                        command += " WHERE StartDate < @now";
                        break;
                    case false:
                        command += " WHERE StartDate >= @now";
                        break;
                }

                return sql.Query<TrainingProgram>(command, new { now = DateTime.Now }).ToList();
            }
        }
    }
}
