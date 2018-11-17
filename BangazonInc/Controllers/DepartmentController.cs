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
    public class DepartmentController : ControllerBase
    {
        DatabaseInterface _db;
        DepartmentStorage _department;

        public DepartmentController (DatabaseInterface db)
        {
            _db = db;
            _department = new DepartmentStorage(db);
        }
        
        [HttpGet]
        public IActionResult GetAll([FromQuery] string include)
        {
            if (include != null)
            {
                if (include == "employees")
                {
                    var deptWithEmployees = _department.GetWithEmployees();
                    return Ok(deptWithEmployees);

                }
            }

            var allDepts = _department.GetDept();
            return Ok(allDepts);
        }

        [HttpPost]
        public IActionResult PostDepartment(Department d)
        {
            var success = _department.AddNew(d);
            
            if (success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateDepartment(Department d)
        {
            var success = _department.Edit(d);

            if (success)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}