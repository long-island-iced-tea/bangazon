using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonInc.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int PaymentType { get; set; }
        public bool Completed { get; set; }
        public bool IsActive { get; set; }
    }
}
