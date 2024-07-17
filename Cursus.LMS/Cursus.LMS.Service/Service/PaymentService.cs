using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;

namespace Cursus.LMS.Service.Service;

public class PaymentService : IPaymentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBalanceService _balanceService;

    public PaymentService(IUnitOfWork unitOfWork, IBalanceService balanceService)
    {
        _unitOfWork = unitOfWork;
        _balanceService = balanceService;
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