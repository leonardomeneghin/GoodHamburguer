using GoodHamburguerAPI.Business;
using GoodHamburguerAPI.Data.VO;
using GoodHamburguerAPI.Model;
using GoodHamburguerAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GoodHamburguerAPI.Controllers
{
    //Configuracion[Host]/api/v1/controller
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{ApiVersion}/[controller]")]
    public class OrderController : Controller
    {
        #region api-global-settings
        private IOrderBusiness _business;
        protected string controllerName = "OrderController";
        #endregion

        public OrderController(IOrderBusiness business)
        {
            _business = business;
        }
        [HttpGet]
        public IActionResult Get() => Ok($"{controllerName} is working");

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
        public IActionResult SendOrder([FromBody] List<ProductVO> products)
        {
            try
            {
                return Ok(_business.MakeOrder(products));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        //TODO: Requirement 08: Create a endpoint to delete a order.
        [HttpDelete]
        [Route("deleteOrder")]
        public IActionResult Delete([FromBody] Order order)
        {
            try
            {
                _business.RemoveOrder(order);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpPut]
        [Route("updateOrder")]
        public IActionResult Update([FromBody] OrderListProductVOBiding objectBiding)
        {
            try
            {
                return Ok(_business.Update(objectBiding.Order, objectBiding.products));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
