using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangazonInc.DataAccess;
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
        public IActionResult Get()
        {
            var allCustomers = _customers.GetCustomers();
            return Ok(allCustomers);
        }
    }
}