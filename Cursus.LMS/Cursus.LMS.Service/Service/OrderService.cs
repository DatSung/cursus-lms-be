using System.Globalization;
using System.Security.Claims;
using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;
using Microsoft.IdentityModel.Tokens;
using Exception = System.Exception;

namespace Cursus.LMS.Service.Service;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderStatusService _orderStatusService;
    private readonly IMapper _mapper;
    private readonly IStripeService _stripeService;
    private readonly IStudentCourseService _studentCourseService;
    private readonly ITransactionService _transactionService;
    private readonly ICourseService _courseService;
    private readonly IBalanceService _balanceService;

    public OrderService
    (
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IOrderStatusService orderStatusService,
        IStripeService stripeService,
        IStudentCourseService studentCourseService,
        ITransactionService transactionService,
        ICourseService courseService,
        IBalanceService balanceService
    )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _orderStatusService = orderStatusService;
        _stripeService = stripeService;
        _studentCourseService = studentCourseService;
        _transactionService = transactionService;
        _courseService = courseService;
        _balanceService = balanceService;
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

            await _orderStatusService.CreateOrderStatus
            (
                User,
                new CreateOrderStatusDTO()
                {
                    Status = StaticStatus.Order.Pending,
                    OrderHeaderId = orderHeader.Id
                }
            );

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

    public async Task<ResponseDTO> GetOrders
    (
        ClaimsPrincipal User,
        Guid? studentId,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber = 1,
        int pageSize = 5
    )
    {
        try
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;
            var role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)!.Value;
            var orders = new List<OrderHeader>();

            if (role.Contains(StaticUserRoles.Student))
            {
                studentId = _unitOfWork.StudentRepository
                    .GetByUserId(userId)
                    .GetAwaiter()
                    .GetResult()!
                    .StudentId;
                orders = _unitOfWork.OrderHeaderRepository
                    .GetAllAsync()
                    .GetAwaiter()
                    .GetResult()
                    .ToList();
            }

            if (role.Contains(StaticUserRoles.Admin))
            {
                if (studentId is null)
                {
                    orders = _unitOfWork.OrderHeaderRepository
                        .GetAllAsync()
                        .GetAwaiter()
                        .GetResult()
                        .ToList();
                }
                else
                {
                    studentId = _unitOfWork.StudentRepository
                        .GetByUserId(userId)
                        .GetAwaiter()
                        .GetResult()!
                        .StudentId;
                    orders = _unitOfWork.OrderHeaderRepository
                        .GetAllAsync(x => x.StudentId == studentId)
                        .GetAwaiter()
                        .GetResult().ToList();
                }
            }

            // Filter Query
            if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterQuery))
            {
                switch (filterOn.Trim().ToLower())
                {
                    case "price":
                    {
                        orders = orders.Where
                        (
                            x => x.OrderPrice.ToString(CultureInfo.InvariantCulture).Contains(filterQuery,
                                StringComparison.CurrentCultureIgnoreCase)).ToList();
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.Trim().ToLower())
                {
                    case "price":
                    {
                        orders = isAscending == true
                            ? [.. orders.OrderBy(x => x.OrderPrice)]
                            : [.. orders.OrderByDescending(x => x.OrderPrice)];
                        break;
                    }
                    case "time":
                    {
                        orders = isAscending == true
                            ? [.. orders.OrderBy(x => x.CreatedTime)]
                            : [.. orders.OrderByDescending(x => x.CreatedTime)];
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }

            // Pagination
            if (pageNumber > 0 && pageSize > 0)
            {
                var skipResult = (pageNumber - 1) * pageSize;
                orders = orders.Skip(skipResult).Take(pageSize).ToList();
            }

            var getOrderHeaderDto = _mapper.Map<List<GetOrderHeaderDTO>>(orders);

            return new ResponseDTO()
            {
                Message = "Get orders successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = getOrderHeaderDto
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

    public async Task<ResponseDTO> PayWithStripe
    (
        ClaimsPrincipal User,
        PayWithStripeDTO payWithStripeDto
    )
    {
        try
        {
            var orderHeader = await _unitOfWork.OrderHeaderRepository.GetAsync
            (
                filter: x => x.Id == payWithStripeDto.OrderHeaderId
            );
            if (orderHeader is null)
            {
                return new ResponseDTO()
                {
                    Message = "Order was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            if (orderHeader.Status != 0)
            {
                return new ResponseDTO()
                {
                    Message = "Order was paid",
                    IsSuccess = false,
                    StatusCode = 400,
                    Result = null
                };
            }

            var orderDetails = await _unitOfWork.OrderDetailsRepository.GetAllAsync
            (
                filter: x => x.OrderHeaderId == orderHeader.Id
            );
            if (orderDetails.IsNullOrEmpty())
            {
                return new ResponseDTO()
                {
                    Message = "Order was empty",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            var responseDto = await _stripeService.CreatePaymentSession
            (
                new CreateStripeSessionDTO()
                {
                    ApprovedUrl = payWithStripeDto.ApprovedUrl,
                    CancelUrl = payWithStripeDto.CancelUrl,
                    OrdersDetails = orderDetails
                }
            );
            var result = (ResponseStripeSessionDTO)responseDto.Result!;

            orderHeader.StripeSessionId = result.StripeSessionId;

            _unitOfWork.OrderHeaderRepository.Update(orderHeader);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                Message = "Create payment with stripe successfully",
                Result = result,
                StatusCode = 200,
                IsSuccess = true
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                Result = null,
                StatusCode = 500,
                IsSuccess = false
            };
        }
    }

    public async Task<ResponseDTO> ValidateWithStripe
    (
        ClaimsPrincipal User,
        ValidateWithStripeDTO validateWithStripeDto
    )
    {
        try
        {
            var orderHeader = await _unitOfWork.OrderHeaderRepository.GetAsync
            (
                filter: x => x.Id == validateWithStripeDto.OrderHeaderId
            );

            if (orderHeader is null)
            {
                return new ResponseDTO()
                {
                    Message = "Order was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            if (orderHeader.Status != StaticStatus.Order.Pending)
            {
                return new ResponseDTO()
                {
                    Message = "Order was validated",
                    Result = null,
                    IsSuccess = true,
                    StatusCode = 200
                };
            }

            var student = await _unitOfWork.StudentRepository.GetAsync(x => x.StudentId == orderHeader.StudentId);

            if (student is null)
            {
                return new ResponseDTO()
                {
                    Message = "Student was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            var responseDto = await _stripeService.ValidatePaymentSession
            (
                new ValidateStripeSessionDTO()
                {
                    StripeSessionId = orderHeader.StripeSessionId
                }
            );
            var result = (ValidateStripeSessionDTO)responseDto.Result!;


            if (result.Status != "succeeded")
            {
                return new ResponseDTO()
                {
                    Message = "Order still processing",
                    IsSuccess = false,
                    StatusCode = 200,
                    Result = null
                };
            }

            orderHeader.PaymentIntentId = result.PaymentIntentId;
            orderHeader.Status = StaticStatus.Order.Paid;
            await _orderStatusService.CreateOrderStatus
            (
                User,
                new CreateOrderStatusDTO()
                {
                    Status = StaticStatus.Order.Paid,
                    OrderHeaderId = orderHeader.Id
                }
            );


            await _transactionService.CreateTransaction
            (
                new CreateTransactionDTO()
                {
                    UserId = student.UserId,
                    Amount = orderHeader.OrderPrice,
                    Type = StaticEnum.TransactionType.Purchase
                }
            );

            var ordersDetails =
                await _unitOfWork.OrderDetailsRepository.GetAllAsync(x => x.OrderHeaderId == orderHeader.Id);

            foreach (var orderDetails in ordersDetails)
            {
                await _studentCourseService.CreateStudentCourse
                (
                    User,
                    new EnrollCourseDTO()
                    {
                        courseId = orderDetails.CourseId,
                        studentId = orderHeader.StudentId
                    }
                );

                await _courseService.UpsertCourseTotal
                (
                    new UpsertCourseTotalDTO()
                    {
                        CourseId = orderDetails.CourseId,
                        TotalEarned = orderDetails.CoursePrice
                    }
                );
            }


            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                Message = "Validate payment with stripe successfully",
                Result = null,
                StatusCode = 200,
                IsSuccess = true
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                Message = e.Message,
                Result = null,
                StatusCode = 500,
                IsSuccess = false
            };
        }
    }

    public async Task<ResponseDTO> ConfirmOrder
    (
        ClaimsPrincipal User,
        Guid orderHeaderId
    )
    {
        try
        {
            var orderHeader = await _unitOfWork.OrderHeaderRepository.GetAsync(x => x.Id == orderHeaderId);
            if (orderHeader is null)
            {
                return new ResponseDTO()
                {
                    Message = "Order was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            if (orderHeader.Status != StaticStatus.Order.Paid)
            {
                return new ResponseDTO()
                {
                    Message = "Order was not paid",
                    IsSuccess = false,
                    StatusCode = 400,
                    Result = null
                };
            }

            orderHeader.Status = StaticStatus.Order.Confirmed;
            _unitOfWork.OrderHeaderRepository.Update(orderHeader);
            await _unitOfWork.SaveAsync();

            await _orderStatusService.CreateOrderStatus
            (
                User,
                new CreateOrderStatusDTO()
                {
                    Status = StaticStatus.Order.Confirmed,
                    OrderHeaderId = orderHeader.Id,
                }
            );

            var ordersDetails =
                await _unitOfWork.OrderDetailsRepository.GetAllAsync(x => x.OrderHeaderId == orderHeader.Id);

            foreach (var orderDetails in ordersDetails)
            {
                await _studentCourseService.UpdateStudentCourse
                (
                    User,
                    new UpdateStudentCourseDTO()
                    {
                        CourseId = orderDetails.CourseId,
                        StudentId = orderHeader.StudentId,
                        Status = StaticStatus.StudentCourse.Confirmed
                    }
                );
            }

            await _balanceService.UpdateAvailableBalanceByOrderId(orderHeaderId);

            return new ResponseDTO()
            {
                Message = "Confirm order successfully",
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
                Result = null,
                IsSuccess = false,
                StatusCode = 500
            };
        }
    }
}