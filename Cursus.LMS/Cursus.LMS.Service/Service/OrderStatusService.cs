using System.Security.Claims;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;

namespace Cursus.LMS.Service.Service;

public class OrderStatusService : IOrderStatusService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderStatusService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<ResponseDTO> GetOrdersStatus(Guid orderHeaderId)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> GetOrderStatus(Guid orderStatusId)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseDTO> CreateOrderStatus(ClaimsPrincipal User, CreateOrderStatusDTO createOrderStatusDto)
    {
        try
        {
            var orderStatus = new OrderStatus()
            {
                Id = new Guid(),
                CreatedBy = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value,
                CreatedTime = DateTime.UtcNow,
                Status = createOrderStatusDto.Status,
                OrderHeaderId = createOrderStatusDto.OrderHeaderId
            };

            await _unitOfWork.OrderStatusRepository.AddAsync(orderStatus);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                Message = "Create order status successfully",
                Result = orderStatus.Id,
                IsSuccess = true,
                StatusCode = 200
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                Result = null,
                IsSuccess = true,
                StatusCode = 500
            };
        }
    }
}