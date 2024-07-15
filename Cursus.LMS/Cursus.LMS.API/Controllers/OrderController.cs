using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace Cursus.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> CreateOrder()
        {
            var responseDto = await _orderService.CreateOrder(User);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("{orderHeaderId:guid}")]
        public async Task<ActionResult<ResponseDTO>> GetOrder([FromRoute] Guid orderHeaderId)
        {
            var responseDto = await _orderService.GetOrder(User, orderHeaderId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("pay-with-stripe")]
        public async Task<ActionResult<ResponseDTO>> PayWithStripe
        (
            [FromBody] PayWithStripeDTO payWithStripeDto
        )
        {
            var responseDto = await _orderService.PayWithStripe(User, payWithStripeDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("validate-with-stripe")]
        public async Task<ActionResult<ResponseDTO>> ValidateWithStripe
        (
            [FromBody] ValidateWithStripeDTO validateWithStripeDto)
        {
            var responseDto = await _orderService.ValidateWithStripe(User, validateWithStripeDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }
    }
}