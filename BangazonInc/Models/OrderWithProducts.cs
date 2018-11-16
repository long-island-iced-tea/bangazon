using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonInc.Models
{
    public class OrderWithProducts : Order
    {
        public List<Product> ProductsInOrder;

        public OrderWithProducts (Order baseOrder, List<Product> products)
        {
            this.CustomerId = baseOrder.CustomerId;
            this.Completed = baseOrder.Completed;
            this.Id = baseOrder.Id;
            this.IsActive = baseOrder.IsActive;
            this.PaymentType = baseOrder.PaymentType;
            this.ProductsInOrder = products;
        }
    }
}
