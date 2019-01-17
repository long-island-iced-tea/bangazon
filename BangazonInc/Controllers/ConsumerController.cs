using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangazonInc.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BangazonInc.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    
    public class ConsumerController : ControllerBase
    {
        DatabaseInterface _db;
        ProductStorage _product;
        UserStorage _user;
        OrderStorage _orders;


        public ConsumerController(DatabaseInterface db)
        {
            _db = db;
            _product = new ProductStorage(db);
        }
        //products GET: Gets all products
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
        //products/recent GET: Gets 20 recent products
        [HttpGet("products/recent")]
        public IActionResult GetRecent()
        {
            return Ok();
        }

        //products? q = GET: Search products, has q as a parameter
        [HttpGet("products/")]
        public IActionResult searchProducts()
        {
            return Ok();
        }
        //products/category GET: Gets products sorted by product type
        [HttpGet("products/catagory/{id}")]

        //GET: Gets product by Id
        [HttpGet("products/{id}")]
        //login GET: returns the authenticated user by uid
        [HttpGet("{id}")]
        public IActionResult getUser(int id) {
            return Ok();
            
        }

        //register GET: adds new customer with firebase uid
        [HttpPost]
        public IActionResult addUser()
        {
            return Ok();
        }
        //order POST adds new order and productorders
    }
}