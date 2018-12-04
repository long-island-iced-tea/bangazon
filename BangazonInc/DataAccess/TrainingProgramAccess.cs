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
                var programs = sql.Query<TrainingProgram>("SELECT * FROM TrainingProgram");

                switch (completed)
                {
                    case true:
                        programs = programs.Where(program => !CheckProgramStartDateIsFuture(program));
                        break;
                    case false:
                        programs = programs.Where(CheckProgramStartDateIsFuture);
                        break;
                }

                return programs.Select(GetAttendeesForTrainingProgram).ToList();
            }
        }

        public TrainingProgram GetSingleProgramById (int id)
        {
            using (var sql = _db.GetConnection())
            {
                var program = sql.QueryFirstOrDefault<TrainingProgram>("SELECT * FROM TrainingProgram WHERE Id = @id", new { id });

                return program == null ? null : GetAttendeesForTrainingProgram(program);
            }
        }

        private TrainingProgram GetAttendeesForTrainingProgram (TrainingProgram baseProgram)
        {
            using (var sql = _db.GetConnection())
            {
                var command = @"SELECT 
                                    e.Id, 
                                    e.firstName, 
                                    e.lastName, 
                                    e.departmentId, 
                                    e.computerId 
                                FROM Employees AS e
                                JOIN EmployeeTraining AS et ON e.Id = et.EmployeeId
                                WHERE et.ProgramId = @id";

                baseProgram.Attendees = sql.Query<Employee>(command, new { baseProgram.Id }).ToList();
                return baseProgram;
            }
        }

        public TrainingProgram AddNewProgram(TrainingProgram programToAdd)
        {
            using (var sql = _db.GetConnection())
            {
                var command = @"INSERT INTO TrainingProgram (name, startDate, endDate, maxAttendees) 
                                OUTPUT INSERTED.*

                                VALUES (@Name, @StartDate, @EndDate, @MaxAttendees)";

                return sql.QueryFirstOrDefault<TrainingProgram>(command, programToAdd);
            }
        }

        public TrainingProgram ModifyProgram(int Id, TrainingProgram updatedProgram)
        {
            using (var sql = _db.GetConnection())
            {
                updatedProgram.Id = Id;

                var command = @"UPDATE TrainingProgram
                                SET name = @Name, startDate = @StartDate, endDate = @EndDate, maxAttendees = @MaxAttendees
                                OUTPUT INSERTED.*
                                WHERE Id = @Id";

                return sql.QueryFirstOrDefault<TrainingProgram>(command, updatedProgram);
            }
        }

        public object DeleteProgram(int Id)
        {
            using (var sql = _db.GetConnection())
            {
                var programToDelete = GetSingleProgramById(Id);

                if (programToDelete == null) return new { Error = "The requested Training Program was not found." };
                
                if (!CheckProgramStartDateIsFuture(programToDelete)) return new { Error = "Cannot delete a Training Program with a start date in the past." };

                return sql.QueryFirstOrDefault<TrainingProgram>("DELETE FROM TrainingProgram OUTPUT DELETED.* WHERE Id = @Id", new { Id });
            }
        }

        public bool CheckProgramStartDateIsFuture(TrainingProgram tp)
        {
            return tp.StartDate >= DateTime.Now.Date;
        }
    }
}
