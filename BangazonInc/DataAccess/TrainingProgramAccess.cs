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

        public List<TrainingProgramWithAttendees> GetAllPrograms(bool? completed)
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

                return sql.Query<TrainingProgram>(command, new { now = DateTime.Now }).Select(GetAttendeesForTrainingProgram).ToList();
            }
        }

        public TrainingProgramWithAttendees GetSingleProgramById (int id)
        {
            using (var sql = _db.GetConnection())
            {
                var program = sql.QueryFirstOrDefault<TrainingProgram>("SELECT * FROM TrainingProgram WHERE Id = @id", new { id });

                return program == null ? null : GetAttendeesForTrainingProgram(program);
            }
        }

        private TrainingProgramWithAttendees GetAttendeesForTrainingProgram (TrainingProgram baseProgram)
        {
            using (var sql = _db.GetConnection())
            {
                var command = @"
SELECT e.Id, e.firstName, e.lastName, e.departmentId, e.computerId FROM Employees AS e
JOIN EmployeeTraining AS et ON e.Id = et.EmployeeId
WHERE et.ProgramId = @id";

                return new TrainingProgramWithAttendees(baseProgram, sql.Query<Employee>(command, new { baseProgram.Id }).ToList());
            }
        }

        public TrainingProgram AddNewProgram(TrainingProgram programToAdd)
        {
            using (var sql = _db.GetConnection())
            {
                var command = @"
INSERT INTO TrainingProgram (name, startDate, endDate, maxAttendees) 
OUTPUT INSERTED.*

VALUES (@Name, @StartDate, @EndDate, @MaxAttendees)";

                return sql.QueryFirstOrDefault<TrainingProgram>(command, programToAdd);
            }
        }
    }
}
