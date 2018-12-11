using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonInc.Models
{
    public class Computer
    {
        public int Id { get; set; }
        public DateTime? purchasedAt { get; set; }
        public DateTime? decommissionedAt { get; set; }
        public DateTime createdAt { get; set; }
        public bool isNew { get; set; }
        public bool isWorking { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }
}
