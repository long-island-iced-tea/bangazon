using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonInc.Models
{
    public class PaymentType
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Int64 AccountNum { get; set; }
        public string Type { get; set; }
    }
}
