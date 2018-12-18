using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonInc.Models
{
    public class Computer
    {
        public int Id { get; set; }
        public DateTime? PurchasedAt { get; set; }
        public DateTime? DecommissionedAt { get; set; }
        public bool IsNew { get; set; }
        public bool IsWorking { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }
}
