using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonInc.Models
{
    public class CustomerWithProducts : Customer
    {
        public CustomerWithProducts(Customer c)
        {
            base.Id = c.Id;
            base.FirstName = c.FirstName;
            base.LastName = c.LastName;
            base.CreatedAt = c.CreatedAt;
            base.IsActive = c.IsActive;
        }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
