using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BangazonInc.DataAccess;

namespace BangazonInc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        DatabaseInterface _db;
        OrderAccess _oa;

        public OrdersController(DatabaseInterface db)
        {
            _db = db;
            _oa = new OrderAccess(db);
        }

        // GET /api/orders
        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(_oa.GetAllOrders());
        }
    }
}