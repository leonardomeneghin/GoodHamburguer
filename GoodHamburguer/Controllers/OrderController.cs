using Microsoft.AspNetCore.Mvc;

namespace GoodHamburguerAPI.Controllers
{
    //Configuracion[Host]/api/v1/controller
    
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        //TODO: Requirement 06: Create a endpoint to list all orders
        [HttpGet]
        [Route("ListOrders")]
        public IActionResult GetOrders()
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        //TODO: Requirement 05: Create a endpoint to send order and return price.
        //obs.: can insert here
        [HttpPost]
        public IActionResult SendOrder()
        {
            try
            {
                return Ok();
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
