using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonInc.Models
{
    public class Computer
    {
        public int Id { get; set; }
        public DateTime PurshasedAt { get; set; }
        public DateTime DecommissionedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool isNew { get; set; }
        public bool isWorking { get; set; }
    }
}
