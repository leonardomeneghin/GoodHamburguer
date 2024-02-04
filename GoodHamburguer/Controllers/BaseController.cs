using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburguerAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{ApiVersion}/[controller]")]
    
    public class BaseController : Controller
    {
        #region api-global-settings
        protected string controllerName = "BaseController";
        #endregion


        [HttpGet]

        public IActionResult Get() 
        {
            return Ok($"Service [controller] is running"); 
        }

        [HttpGet("action")]
        public IActionResult Action()
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
