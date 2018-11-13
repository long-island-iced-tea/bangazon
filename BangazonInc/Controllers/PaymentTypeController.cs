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
    public class PaymentTypeController : ControllerBase
    {
        DatabaseInterface _db;
        PaymentTypeStorage _paymentType;

        public PaymentTypeController(DatabaseInterface db)
        {
            _db = db;
            _paymentType = new PaymentTypeStorage(db);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allPayType = _paymentType.GetAllPaymentTypes();
            return Ok(allPayType);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_paymentType.GetById(id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePaymentType(int id)
        {
            var paymentType = _paymentType.GetById(id);
            if (paymentType == null)
            {
                return NotFound();
            }
            var success = _paymentType.DeleteById(id);
            if (success)
            {
                return Ok();
            }

            return BadRequest(new { Message = "Delete was unsuccessful" });
        }

        [HttpPut("{id}")]
        public void UpdatePaymentType(int id, [FromBody] string value)
        {
            
        }
    }
}
