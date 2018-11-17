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
        public IActionResult GetAll()
        {
            var allDepts = _department.GetDept();
            return Ok(allDepts);
        }

         
    }
}