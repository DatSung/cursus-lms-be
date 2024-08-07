using System.Security.Claims;
using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;

namespace Cursus.LMS.Service.Service;

public class OrderStatusService : IOrderStatusService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderStatusService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseDTO> GetOrdersStatus(Guid orderHeaderId)
    {
        try
        {
            var orderStatus = await _unitOfWork.OrderStatusRepository
                .GetAllAsync(x => x.OrderHeaderId == orderHeaderId);

            var orderStatusDto = _mapper.Map<List<GetOrdersStatusDTO>>(orderStatus);

            return new ResponseDTO()
            {
                Message = "Get order status successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = orderStatusDto
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                Result = null,
                IsSuccess = false,
                StatusCode = 500
            };
        }
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