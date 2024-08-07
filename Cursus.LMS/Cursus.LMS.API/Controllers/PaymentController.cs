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
        private readonly IBalanceService _balanceService;

        public PaymentController
        (
            IPaymentService paymentService,
            ITransactionService transactionService,
            IBalanceService balanceService)
        {
            _paymentService = paymentService;
            _transactionService = transactionService;
            _balanceService = balanceService;
        }

        [HttpGet]
        [Route("system/balance")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> GetSystemBalance()
        {
            var responseDto = await _balanceService.GetSystemBalance(User);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("instructor/balance")]
        [Authorize(Roles = StaticUserRoles.AdminInstructor)]
        public async Task<ActionResult<ResponseDTO>> GetInstructorBalance([FromQuery] string? userId)
        {
            var responseDto = await _balanceService.GetInstructorBalance(User, userId);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("transaction")]
        [Authorize]
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
        [Route("stripe/account")]
        [Authorize(Roles = StaticUserRoles.Instructor)]
        public async Task<ActionResult<ResponseDTO>> CreateStripeConnectedAccount
        (
            CreateStripeConnectedAccountDTO createStripeConnectedAccountDto
        )
        {
            var responseDto = await _paymentService.CreateStripeConnectedAccount(User, createStripeConnectedAccountDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("stripe/transfer")]
        [Authorize(Roles = StaticUserRoles.Admin)]
        public async Task<ActionResult<ResponseDTO>> CreateStripeTransfer
        (
            CreateStripeTransferDTO createStripeTransferDto)
        {
            var responseDto = await _paymentService.CreateStripeTransfer(createStripeTransferDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("stripe/payout")]
        [Authorize(Roles = StaticUserRoles.Instructor)]
        public async Task<ActionResult<ResponseDTO>> CreateStripePayout(CreateStripePayoutDTO createStripePayoutDto)
        {
            var responseDto = await _paymentService.CreateStripePayout(User, createStripePayoutDto);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("stripe/card")]
        [Authorize(Roles = StaticUserRoles.Instructor)]
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