using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangazonInc.DataAccess;
using BangazonInc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BangazonInc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        DatabaseInterface _db;
        CustomerStorage _customers;


        public CustomersController(DatabaseInterface db)
        {
            _db = db;
            _customers = new CustomerStorage(db);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int? id, string include, string q, bool? active)
        {
            if (id != null)
            {
                var customer = _customers.GetCustomerById(id);
                return Ok(customer);
            }

            if (include != null)
            {
                if (include == "products")
                {
                    return Ok(_customers.GetCustomersWithProducts());
                }
                if (include == "payments")
                {
                    return Ok(_customers.GetCustomersWithPayments());
                }
            }

            if (q != null)
            {
                return Ok(_customers.GetCustomersByTerm(q));
            }

            if (active != null)
            {
                return Ok(_customers.GetCustomersWithOrders(active));
            }
            var allCustomers = _customers.GetCustomers();
            return Ok(allCustomers);

        }

        [HttpPost]
        public IActionResult AddCustomer(Customer newCustomer)
        {
            var insertedCustomer = _customers.AddNew(newCustomer);

            return insertedCustomer == default(Customer)
                ? BadRequest() as IActionResult
                : Ok(insertedCustomer);
        }

        [HttpPut]
        public IActionResult UpdateCustomer(Customer newCustomer)
        {
            var success = _customers.UpdateCustomer(newCustomer);
            
            if (success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}