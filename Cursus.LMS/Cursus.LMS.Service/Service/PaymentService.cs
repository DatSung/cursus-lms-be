using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;

namespace Cursus.LMS.Service.Service;

public class PaymentService : IPaymentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBalanceService _balanceService;
    private readonly ITransactionService _transactionService;

    public PaymentService
    (
        IUnitOfWork unitOfWork,
        IBalanceService balanceService,
        ITransactionService transactionService
    )
    {
        _unitOfWork = unitOfWork;
        _balanceService = balanceService;
        _transactionService = transactionService;
    }

    public async Task<ResponseDTO> UpdateBalanceByOrderId(Guid orderHeaderId)
    {
        try
        {
            var ordersDetails =
                await _unitOfWork.OrderDetailsRepository.GetAllAsync(x => x.OrderHeaderId == orderHeaderId);

            foreach (var orderDetails in ordersDetails)
            {
                var course = await _unitOfWork.CourseRepository.GetAsync
                (
                    x => x.Id == orderDetails.CourseId
                );

                var instructor = await _unitOfWork.InstructorRepository.GetAsync
                (
                    x => x.InstructorId == course.InstructorId
                );

                await _balanceService.UpsertBalance(
                    new UpsertBalanceDTO()
                    {
                        Currency = "usd",
                        AvailableBalance = orderDetails.CoursePrice,
                        PendingBalance = 0,
                        UserId = instructor.UserId
                    }
                );

                await _transactionService.CreateTransaction
                (
                    new CreateTransactionDTO()
                    {
                        UserId = instructor.UserId,
                        Amount = orderDetails.CoursePrice,
                        Type = StaticEnum.TransactionType.Income,
                    }
                );
            }

            return new ResponseDTO()
            {
                Message = "Update balance successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = null
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                IsSuccess = false,
                StatusCode = 500,
                Result = null
            };
        }
    }
}