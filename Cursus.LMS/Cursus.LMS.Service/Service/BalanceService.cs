using System.Security.Claims;
using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;

namespace Cursus.LMS.Service.Service;

public class BalanceService : IBalanceService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BalanceService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseDTO> GetBalance(ClaimsPrincipal User, string? userId)
    {
        try
        {
            var role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)!.Value;
            var balance = new Balance();

            if (role.Contains(StaticUserRoles.Admin))
            {
                if (userId is null)
                {
                    return new ResponseDTO()
                    {
                        IsSuccess = false,
                        Message = "User was not found",
                        StatusCode = 404,
                        Result = null
                    };
                }

                balance = await _unitOfWork.BalanceRepository.GetAsync(x => x.UserId == userId);
            }

            if (role.Contains(StaticUserRoles.Instructor))
            {
                userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;
                balance = await _unitOfWork.BalanceRepository.GetAsync(x => x.UserId == userId);
            }

            var getBalanceDto = _mapper.Map<GetBalanceDTO>(balance);

            return new ResponseDTO()
            {
                IsSuccess = true,
                Message = "Get balance successfully",
                StatusCode = 200,
                Result = getBalanceDto
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
                    TotalBalance = upsertBalanceDto.TotalBalance,
                    AvailableBalance = upsertBalanceDto.AvailableBalance,
                    PayoutBalance = upsertBalanceDto.PayoutBalance,
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

            balance.TotalBalance += upsertBalanceDto.TotalBalance;
            balance.AvailableBalance += upsertBalanceDto.AvailableBalance;
            balance.PayoutBalance += upsertBalanceDto.PayoutBalance;
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