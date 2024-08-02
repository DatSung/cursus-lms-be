using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cursus.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderStatusService _orderStatusService;

        public OrderController(IOrderService orderService, IOrderStatusService orderStatusService)
        {
            _orderService = orderService;
            _orderStatusService = orderStatusService;
        }

        [HttpPost]
        [Authorize(Roles = StaticUserRoles.Student)]
        public async Task<ActionResult<ResponseDTO>> CreateOrder()
        {
            var responseDto = await _orderService.CreateOrder(User);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Authorize(Roles = StaticUserRoles.AdminStudent)]
        public async Task<ActionResult<ResponseDTO>> GetOrders
        (
            [FromQuery] Guid? studentId,
            [FromQuery] string? filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy,
            [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5
        )
        {
            var responseDto = await _orderService.GetOrders
            (
                User,
                studentId,
                filterOn,
                filterQuery,
                sortBy,
                isAscending,
                pageNumber,
                pageSize
            );

            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("{orderHeaderId:guid}")]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> GetOrder([FromRoute] Guid orderHeaderId)
        {
            var responseDto = await _orderService.GetOrder(User, orderHeaderId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("status/{orderHeaderId:guid}")]
        [Authorize(Roles = StaticUserRoles.AdminStudent)]
        public async Task<ActionResult<ResponseDTO>> GetOrderStatus([FromRoute] Guid orderHeaderId)
        {
            var responseDto = await _orderStatusService.GetOrdersStatus(orderHeaderId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("stripe/checkout")]
        [Authorize(Roles = StaticUserRoles.Student)]
        public async Task<ActionResult<ResponseDTO>> PayWithStripe
        (
            [FromBody] PayWithStripeDTO payWithStripeDto
        )
        {
            var responseDto = await _orderService.PayWithStripe(User, payWithStripeDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("stripe/validate")]
        [Authorize(Roles = StaticUserRoles.AdminStudent)]
        public async Task<ActionResult<ResponseDTO>> ValidateWithStripe
        (
            [FromBody] ValidateWithStripeDTO validateWithStripeDto
        )
        {
            var responseDto = await _orderService.ValidateWithStripe(User, validateWithStripeDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPut]
        [Route("confirm/{orderHeaderId:guid}")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> ConfirmOrder([FromRoute] Guid orderHeaderId)
        {
            var responseDto = await _orderService.ConfirmOrder(User, orderHeaderId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }
    }
}