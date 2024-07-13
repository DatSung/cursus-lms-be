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
        [Route("create-stripe-session")]
        public async Task<ActionResult<ResponseDTO>> CreateStripeSession([FromBody] StripeRequestDTO stripeRequestDto)
        {
            var responseDto = await _orderService.CreateStripeSession(User, stripeRequestDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }
        
        [HttpPost]
        [Route("validate-stripe-session")]
        public async Task<ActionResult<ResponseDTO>> ValidateStripeSession([FromBody] ValidateStripeSessionDTO validateStripeSessionDto)
        {
            var responseDto = await _orderService.ValidateStripeSession(User, validateStripeSessionDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }
    }
}