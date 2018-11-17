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
    public class TrainingProgramController : ControllerBase
    {
        TrainingProgramAccess _tpa;

        public TrainingProgramController(DatabaseInterface db)
        {
            _tpa = new TrainingProgramAccess(db);
        }

        // GET /api/trainingprogram
        [HttpGet]
        public IActionResult GetTrainingPrograms([FromQuery] bool? completed)
        {
            return Ok(_tpa.GetAllPrograms(completed));
        }

        // GET /api/trainingprogram/5
        [HttpGet("{id}")]
        public IActionResult GetSingleTrainingProgram(int id)
        {
            var requestedTrainingProgram = _tpa.GetSingleProgramById(id);
            return requestedTrainingProgram == null
                ? BadRequest() as IActionResult
                : Ok(requestedTrainingProgram);
        }
    }
}