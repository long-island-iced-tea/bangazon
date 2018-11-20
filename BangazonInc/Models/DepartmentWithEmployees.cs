using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonInc.Models
{
    public class DepartmentWithEmployees : Department
    {
        public DepartmentWithEmployees(Department d)
        {
            base.Id = d.Id;
            base.Name = d.Name;
            base.Budget = d.Budget;
            base.SupervisorId = d.SupervisorId;
        }

        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
