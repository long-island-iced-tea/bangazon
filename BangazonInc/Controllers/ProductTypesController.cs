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
    public class ProductTypesController : ControllerBase
    {
        DatabaseInterface _db;
        ProductTypeStorage _ptypes;

        public ProductTypesController(DatabaseInterface db)
        {
            _db = db;
            _ptypes = new ProductTypeStorage(db);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_ptypes.GetProductTypes());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_ptypes.GetById(id));
        }

        [HttpPost]
        public IActionResult AddProductType(ProductType ptype)
        {
            return Ok(_ptypes.AddNew(ptype));
        }

        [HttpPut]
        public IActionResult UpdateProductType(ProductType ptype)
        {
            return Ok(_ptypes.Edit(ptype));
        }
    }
}