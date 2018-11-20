using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonInc.Models
{
    public class EmployeeComputer: Computer
    {
        public EmployeeComputer(Computer c)
        {
            base.Id = c.Id;
            base.purchasedAt = c.purchasedAt;
            base.decommissionedAt = c.decommissionedAt;
            base.isNew = c.isNew;
            base.isWorking = c.isWorking;
        }
    }
}
