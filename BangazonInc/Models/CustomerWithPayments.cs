using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonInc.Models
{
    public class CustomerWithPayments : Customer
    {
        public CustomerWithPayments(Customer c)
        {
            base.Id = c.Id;
            base.FirstName = c.FirstName;
            base.LastName = c.LastName;
            base.CreatedAt = c.CreatedAt;
            base.IsActive = c.IsActive;
        }

        public List<PaymentType> Payments { get; set; } = new List<PaymentType>();
    }
}
