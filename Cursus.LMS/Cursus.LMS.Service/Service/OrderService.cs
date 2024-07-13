using System.Security.Claims;
using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;
using Microsoft.IdentityModel.Tokens;

namespace Cursus.LMS.Service.Service;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseDTO> CreateOrder
    (
        ClaimsPrincipal User
    )
    {
        try
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var student = await _unitOfWork.StudentRepository.GetAsync
            (
                filter: x => x.UserId == userId,
                includeProperties: "ApplicationUser"
            );
            if (student is null)
            {
                return new ResponseDTO()
                {
                    Message = "Student was not found",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 404
                };
            }

            var cartHeader = await _unitOfWork.CartHeaderRepository.GetAsync(x => x.StudentId == student.StudentId);
            if (cartHeader is null)
            {
                cartHeader = new CartHeader()
                {
                    StudentId = student.StudentId,
                    Id = Guid.NewGuid(),
                    TotalPrice = 0
                };
                await _unitOfWork.CartHeaderRepository.AddAsync(cartHeader);
                await _unitOfWork.SaveAsync();

                return new ResponseDTO()
                {
                    Message = "Cart was not found",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 400
                };
            }

            var cartDetails = await _unitOfWork.CartDetailsRepository.GetAllAsync(x => x.CartHeaderId == cartHeader.Id);
            if (cartDetails.IsNullOrEmpty())
            {
                return new ResponseDTO()
                {
                    Message = "Cart is empty",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 400
                };
            }

            var orderHeader = new OrderHeader()
            {
                Id = Guid.NewGuid(),
                StudentId = student.StudentId,
                Status = StaticStatus.Order.Pending,
                CreatedBy = student.ApplicationUser.Email,
                CreatedTime = DateTime.UtcNow,
                OrderPrice = cartHeader.TotalPrice
            };

            var orderDetails = new List<OrderDetails>();
            foreach (var cartDetail in cartDetails)
            {
                var orderDetail = new OrderDetails()
                {
                    Id = Guid.NewGuid(),
                    CourseId = cartDetail.CourseId,
                    OrderHeaderId = orderHeader.Id,
                    CoursePrice = cartDetail.CoursePrice,
                    CourseTitle = cartDetail.CourseTitle
                };
                orderDetails.Add(orderDetail);
            }

            await _unitOfWork.OrderHeaderRepository.AddAsync(orderHeader);
            await _unitOfWork.OrderDetailsRepository.AddRangeAsync(orderDetails);

            _unitOfWork.CartDetailsRepository.RemoveRange(cartDetails);
            cartHeader.TotalPrice = 0;
            _unitOfWork.CartHeaderRepository.Update(cartHeader);

            await _unitOfWork.SaveAsync();

            var orderHeaderDto = _mapper.Map<GetOrderHeaderDTO>(orderHeader);
            return new ResponseDTO()
            {
                Message = "Create order successfully",
                Result = orderHeaderDto,
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
                IsSuccess = false,
                StatusCode = 500
            };
        }
    }

    public async Task<ResponseDTO> GetOrder
    (
        ClaimsPrincipal User,
        Guid orderHeaderId
    )
    {
        try
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            var student = await _unitOfWork.StudentRepository.GetAsync(x => x.UserId == userId);
            if (student is null)
            {
                return new ResponseDTO()
                {
                    Message = "Student was not found",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 404
                };
            }

            var orderHeader = await _unitOfWork.OrderHeaderRepository.GetAsync(x => x.Id == orderHeaderId);
            var orderDetails =
                await _unitOfWork.OrderDetailsRepository.GetAllAsync(x => x.OrderHeaderId == orderHeaderId);

            var getOrderHeaderDto = _mapper.Map<GetOrderHeaderDTO>(orderHeader);
            getOrderHeaderDto.GetOrderDetails = _mapper.Map<List<GetOrderDetailsDTO>>(orderDetails);

            return new ResponseDTO()
            {
                Message = "Get order successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = getOrderHeaderDto
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
            };
        }
    }

    public Task<ResponseDTO> CreateStripeSession
    (
        ClaimsPrincipal User,
        StripeRequestDTO stripeRequestDto
    )
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> ValidateStripeSession
    (
        ClaimsPrincipal User,
        ValidateStripeSessionDTO validateStripeSessionDto
    )
    {
        throw new NotImplementedException();
    }
}