using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonInc.Models
{
    public class OrderWithCustomer : Order
    {
        public Customer AssociatedCustomer;

        public OrderWithCustomer (Order baseOrder, Customer customer)
        {
            this.CustomerId = baseOrder.CustomerId;
            this.Completed = baseOrder.Completed;
            this.Id = baseOrder.Id;
            this.IsActive = baseOrder.IsActive;
            this.PaymentType = baseOrder.PaymentType;
            this.AssociatedCustomer = customer;
        }
    }
}
