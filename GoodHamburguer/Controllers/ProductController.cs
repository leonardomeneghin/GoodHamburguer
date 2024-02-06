using GoodHamburguerAPI.Business;
using GoodHamburguerAPI.Business.implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburguerAPI.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{ApiVersion}/[controller]")]
    public class ProductController : Controller
    {
        #region api-global-settings
        protected string controllerName = "ProductController";
        private IProductBusiness _productBusiness;
        #endregion

        public ProductController(IProductBusiness product)
        {
            _productBusiness = product;
        }
        [HttpGet]

        public IActionResult Get()
        {
            return Ok($"Service {controllerName} is running");
        }
        //TODO: Requirement 01 List sandwishes and extras
        [HttpGet]
        [Route("ListSandwichAndExtras")]
        public IActionResult ListAllSandwichAndExtras()
        {
            try
            {
                return Ok(_productBusiness.ListAllMenuItems());
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
                
                return Ok(_productBusiness.ListSandwiches());
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
                return Ok(_productBusiness.ListExtras());
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
