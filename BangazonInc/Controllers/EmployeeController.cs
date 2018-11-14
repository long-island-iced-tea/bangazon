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
    public class EmployeeController : ControllerBase
    {
        DatabaseInterface _db;
        EmployeeStorage _Employees;

        public EmployeeController(DatabaseInterface db)
        {
            _db = db;
            _Employees = new EmployeeStorage(db);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allPayType = _Employees.GetAllEmployees();
            return Ok(allPayType);
        }
    }
}
