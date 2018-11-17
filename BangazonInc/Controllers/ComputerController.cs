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

        [HttpGet("{id}")]
        public IActionResult GetComputerById(int id)
        {
            var singleComputer = _computer.GetComputerById(id);
            return Ok(singleComputer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var computer = _computer.GetComputerById(id);

            if (computer == null)
            {
                return NotFound();
            }

            var success = _computer.DeleteById(id);

            if (success)
            {
                return Ok();
            }
            return BadRequest(new { Message = "Delete was unsuccessful" });
        }

        [HttpPut("computer")]
        public IActionResult UpdateComputer(Computer computer)
        {
            var computers = _computer.UpdateComputer(computer);
            return Ok();
        }

        [HttpPost("computer")]
        public IActionResult PostComputer(Computer computer)
        {
            var computers = _computer.PostComputer(computer);
                return Ok();
        }
    }
}