using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Service.Service;
using Cursus.LMS.Utility.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cursus.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly ITransactionService _transactionService;

        public PaymentController(IPaymentService paymentService, ITransactionService transactionService)
        {
            _paymentService = paymentService;
            _transactionService = transactionService;
        }

        [HttpGet]
        [Route("get-transaction-history")]
        public async Task<ActionResult<ResponseDTO>> GetTransactionHistory
        (
            [FromQuery] string? userId,
            [FromQuery] string? filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy,
            [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5
        )
        {
            var responseDto = await _transactionService.GetTransactions
            (
                User,
                userId,
                filterOn,
                filterQuery,
                sortBy,
                isAscending,
                pageNumber,
                pageSize
            );
            return StatusCode(responseDto.StatusCode, responseDto);
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

        [HttpGet]
        [Route("get-top-Instructors-Payout")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> GetTopInstructorsByPayout
        (
            [FromQuery] int topN,
            [FromQuery] int? filterYear,
            [FromQuery] int? filterMonth,
            [FromQuery] int? filterQuarter
        )
        {
            var responseDto = await _paymentService.GetTopInstructorsByPayout
                (
                    topN,
                    filterYear,
                    filterMonth,
                    filterQuarter
                );
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("get-least-Instructors-Payout")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> GetLeastInstructorsByPayout
        (
            [FromQuery] int topN,
            [FromQuery] int? filterYear,
            [FromQuery] int? filterMonth,
            [FromQuery] int? filterQuarter
        )
        {
            var responseDto = await _paymentService.GetLeastInstructorsByPayout
                (
                    topN,
                    filterYear,
                    filterMonth,
                    filterQuarter
                );
            return StatusCode(responseDto.StatusCode, responseDto);
        }
    }
}