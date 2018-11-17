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
    public class ComputerController : ControllerBase
    {
        DatabaseInterface _db;
        ComputerStorage _computer;

        public ComputerController(DatabaseInterface db)
        {
            _db = db;
            _computer = new ComputerStorage(db);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allComputers = _computer.GetComputer();
            return Ok(allComputers);
        }
    }
}