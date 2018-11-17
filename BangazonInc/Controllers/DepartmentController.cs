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

        public DepartmentController(DatabaseInterface db)
        {
            _db = db;
            _department = new DepartmentStorage(db);
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var allDepts = _department.GetDept();
            return Ok(allDepts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var singleDept = _department.GetDeptById(id);
            return Ok(singleDept);
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
    }
}