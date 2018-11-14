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
    public class ProductController : ControllerBase
    {
        DatabaseInterface _db;
        ProductStorage _product;

        public ProductController(DatabaseInterface db)
        {
            _db = db;
            _product = new ProductStorage(db);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var allProducts = _product.GetProduct();
            return Ok(allProducts);
        }

        //[HttpGet("{id}")]
        //public IActionResult GetProductById(int id)
        //{
        //    var singleProduct = _product.GetProductById(id);
        //    return Ok(singleProduct);
        //}
    }
}