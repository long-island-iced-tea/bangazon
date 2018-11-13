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
        public IActionResult Get()
        {
            var allPayType = _paymentType.GetPaymentTypes();
            return Ok(allPayType);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_paymentType.GetPaymentTypeById(id));
        }
    }
}
