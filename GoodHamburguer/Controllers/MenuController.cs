using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburguerAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : Controller
    {
        //TODO: Requirement 01 List sandwishes and extras
        [HttpGet]
        public IActionResult ListAllSandwichAndExtras()
        {
            try
            {
                return Ok();
                //Log Sucess
            }
            catch (Exception ex)
            {
                //Log error
                return BadRequest(ex.Message);
            }

        }
        //TODO: Requirement 02: List all sandwiches only.
        [HttpGet]
        [Route("ListSandwiches")]
        public IActionResult ListSandwich()
        {
            try
            {
                return Ok();
                //Log Sucess
            }
            catch (Exception ex)
            {
                //Log error
                return BadRequest(ex.Message);
            }

        }

        //TODO: Requirement 02: List all extras only.
        [HttpGet]
        [Route("ListExtras")]
        public IActionResult ListExtras()
        {
            try
            {
                return Ok();
                //Log Sucess
            }
            catch (Exception ex)
            {
                //Log error
                return BadRequest(ex.Message);
            }
        }

    }
}
