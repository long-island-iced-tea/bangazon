using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BangazonInc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypesController : ControllerBase
    {
        DatabaseInterface _db;

        public ProductTypesController(DatabaseInterface db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}