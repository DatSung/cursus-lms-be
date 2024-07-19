using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;

namespace Cursus.LMS.Service.Service;

public class BalanceService : IBalanceService
{
    private readonly IUnitOfWork _unitOfWork;

    public BalanceService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseDTO> UpsertBalance(UpsertBalanceDTO upsertBalanceDto)
    {
        try
        {
            var balance = await _unitOfWork.BalanceRepository.GetAsync(x => x.UserId == upsertBalanceDto.UserId);
            if (balance is null)
            {
                balance = new Balance()
                {
                    Currency = "usd",
                    UserId = upsertBalanceDto.UserId,
                    AvailableBalance = upsertBalanceDto.AvailableBalance,
                    PayoutBalance = upsertBalanceDto.PendingBalance,
                    UpdatedTime = DateTime.UtcNow
                };

                await _unitOfWork.BalanceRepository.AddAsync(balance);
                await _unitOfWork.SaveAsync();

                return new ResponseDTO()
                {
                    IsSuccess = true,
                    Message = "Upsert balance successfully",
                    Result = null,
                    StatusCode = 200
                };
            }

            balance.AvailableBalance += upsertBalanceDto.AvailableBalance;
            balance.PayoutBalance += upsertBalanceDto.PendingBalance;
            balance.UpdatedTime = DateTime.UtcNow;

            _unitOfWork.BalanceRepository.Update(balance);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                IsSuccess = true,
                Message = "Upsert balance successfully",
                Result = null,
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                IsSuccess = false,
                Message = e.Message,
                Result = null,
                StatusCode = 500
            };
        }
    }
}