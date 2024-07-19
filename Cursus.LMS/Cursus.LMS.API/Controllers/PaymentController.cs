using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cursus.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        [Route("create-stripe-connected-account")]
        public async Task<ActionResult<ResponseDTO>> CreateStripeConnectedAccount
        (
            CreateStripeConnectedAccountDTO createStripeConnectedAccountDto
        )
        {
            var responseDto = await _paymentService.CreateStripeConnectedAccount(createStripeConnectedAccountDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("create-stripe-transfer")]
        public async Task<ActionResult<ResponseDTO>> CreateStripeTransfer
        (
            CreateStripeTransferDTO createStripeTransferDto)
        {
            var responseDto = await _paymentService.CreateStripeTransfer(createStripeTransferDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("create-stripe-payout")]
        public async Task<ActionResult<ResponseDTO>> CreateStripePayout(CreateStripePayoutDTO createStripePayoutDto)
        {
            var responseDto = await _paymentService.CreateStripePayout(User, createStripePayoutDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("add-stripe-card")]
        public async Task<ActionResult<ResponseDTO>> AddStripeCard
        (
            AddStripeCardDTO addStripeCardDto
        )
        {
            var responseDto = await _paymentService.AddStripeCard(addStripeCardDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }
    }
}