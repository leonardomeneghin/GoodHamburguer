using GoodHamburguerAPI.Business;
using GoodHamburguerAPI.Model;
using GoodHamburguerAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GoodHamburguerAPI.Controllers
{
    //Configuracion[Host]/api/v1/controller
    
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private IOrderBusiness _business;
        public OrderController(IOrderBusiness business)
        {
            _business = business;
        }
        //TODO: Requirement 06: Create a endpoint to list all orders
        [HttpGet]
        [Route("ListOrders")]
        public IActionResult GetOrders()
        {
            try
            {
                return Ok(_business.ListOrders());
                //Log sucess
            }
            catch (Exception)
            {
                //Log error
                return BadRequest();
            }
        }
        //TODO: Requirement 05: Create a endpoint to send order and return price.
        [HttpPost]
        [Route("SendOrder")]
        public IActionResult SendOrder([FromBody] List<Product> products)
        {
            try
            {
                return Ok(_business.MakeOrder(products));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        //TODO: Requirement 08: Create a endpoint to delete a order.
        [HttpDelete]
        public IActionResult Delete()
        {
            try
            {
                return NoContent();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
