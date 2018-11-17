using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonInc.Models
{
    public class TrainingProgramWithAttendees : TrainingProgram
    {
        public List<Employee> Attendees = new List<Employee>();

        public TrainingProgramWithAttendees(TrainingProgram baseProgram, List<Employee> attendees)
        {
            Attendees = attendees;
            this.EndDate = baseProgram.EndDate;
            this.Id = baseProgram.Id;
            this.MaxAttendees = baseProgram.MaxAttendees;
            this.Name = baseProgram.Name;
            this.StartDate = baseProgram.StartDate;
        }
    }
}
