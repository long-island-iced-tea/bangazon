using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangazonInc.DataAccess;
using BangazonInc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BangazonInc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ConsumerController : ControllerBase
    {
        DatabaseInterface _db;
        ProductStorage _product;
        CustomerStorage _user;
        OrderAccess _orders;

        public ConsumerController(DatabaseInterface db)
        {
            _db = db;
            _product = new ProductStorage(db);
            _user = new CustomerStorage(db);
            _orders = new OrderAccess(db);
        }

        //products GET: Gets all products
        [HttpGet("products")]
        public IActionResult Get()
        {
            var allProducts = _product.GetProduct();
            return Ok(allProducts);
        }


        //products/recent GET: Gets 20 recent products
        [HttpGet("products/recent")]
        public IActionResult GetRecentProducts()
        {
            return Ok();
        }

        //products? q = GET: Search products, has q as a parameter

        [HttpGet("products/search")]
        public IActionResult Get([FromQuery] string q)
        {
                return Ok();  
        }

        //products/category GET: Gets products sorted by product type
        [HttpGet("products/category")]

        //GET: Gets product by Id
        [HttpGet("products/{id}")]
        public IActionResult GetProductById(int id)
        {
            var singleProduct = _product.GetProductById(id);
            return Ok(singleProduct);
        }

        //login GET: returns the authenticated user by uid
        [HttpGet("login")]
        public IActionResult getUser(int id) {
            var user = _user.GetCustomerById(id);
            return Ok(user);
        }

        //register POST: new customer with firebase uid
        [HttpPost("register")]
        public IActionResult AddCustomer(Customer newCustomer)
        {
            var insertedCustomer = _user.AddNew(newCustomer);

            return insertedCustomer == default(Customer)
                ? BadRequest() as IActionResult
                : Ok(insertedCustomer);
        }
        //order POST adds new order and productorders
        [HttpPost("order")]
        public IActionResult AddNewOrder(Order newOrder)
        {
            return Ok(_orders.AddNewOrder(newOrder));
        }
    }
}