using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonInc.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public int ComputerId { get; set; }
        public string DepartmentName { get; set; }
        public string PurchasedAt { get; set; }
        public string DecommissionedAt { get; set; }
        public bool IsNew { get; set; }
        public bool IsWorking { get; set; }
    }
}
