﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace BangazonInc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        DatabaseInterface _db;
        //

        public ValuesController(DatabaseInterface db)
        {
            _db = db;
            // Instantiate new storage class here
            // _values = new ValuesStorage(db);
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            using (var connection = _db.GetConnection())
            {
                string sql = "SELECT TOP 5 firstName FROM Customers";
                var firstFive = connection.Query<string>(sql).ToList();
                if (firstFive.Count == 5)
                {
                    return Ok(firstFive);
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
