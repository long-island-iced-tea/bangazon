using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonInc.Models
{
    public class ComputerWithEmployeeId : Computer
    {
        public ComputerWithEmployeeId() { }

        public ComputerWithEmployeeId(Computer computer)
        {
            if (computer.DecommissionedAt is null)
            {
                this.DecommissionedAt = null;
            }
            else
            {
                this.DecommissionedAt = computer.DecommissionedAt;
            }
            this.Id = computer.Id;
            this.IsNew = computer.IsNew;
            this.IsWorking = computer.IsWorking;
            if (computer.PurchasedAt is null)
            {
                this.PurchasedAt = null;
            }
            else
            {
                this.PurchasedAt = computer.PurchasedAt;
            }
        }
        
        public int? EmployeeId { get; set; }
    }
}
