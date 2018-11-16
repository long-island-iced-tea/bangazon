using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BangazonInc.DataAccess;
using BangazonInc.Models;

namespace BangazonInc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        OrderAccess _oa;

        public OrdersController(DatabaseInterface db)
        {
            _oa = new OrderAccess(db);
        }

        // GET /api/orders
        [HttpGet]
        public IActionResult GetOrders([FromQuery] bool? completed, [FromQuery] string _include)
        {
            return Ok(_oa.GetAllOrders(completed, _include));
        }

        // GET /api/orders/5
        [HttpGet("{id}")]
        public IActionResult GetSingleOrder(int id, [FromQuery] string _include)
        {
            var requestedOrder = _oa.GetSingleOrder(id, _include);
            return requestedOrder == null
                ? BadRequest() as IActionResult
                : Ok(requestedOrder);
        }

        // POST /api/orders
        [HttpPost]
        public IActionResult AddNewOrder(Order newOrder)
        {
            return Ok(_oa.AddNewOrder(newOrder));
        }

        // DELETE /api/orders/5
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var rowsDeleted = _oa.DeleteOrder(id);

            return rowsDeleted >= 1
                ? Ok(new { rowsDeleted })
                : BadRequest(new { rowsDeleted }) as IActionResult;
        }

        // PUT /api/orders/5
        [HttpPut("{id}")]
        public IActionResult ModifyOrder (int id, Order newOrder)
        {
            newOrder.Id = id;
            var rowsChanged = _oa.ModifyOrder(newOrder);

            return rowsChanged == null
                ? BadRequest() as IActionResult
                : Ok(rowsChanged);
        }
    }
}