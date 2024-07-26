using System.Security.Claims;
using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;

namespace Cursus.LMS.Service.Service;

public class CartService : ICartService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CartService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseDTO> GetCart(ClaimsPrincipal User)
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
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            var cartHeader = await _unitOfWork.CartHeaderRepository.GetAsync(x => x.StudentId == student.StudentId);

            if (cartHeader is null)
            {
                cartHeader = new CartHeader()
                {
                    Id = Guid.NewGuid(),
                    StudentId = student.StudentId,
                    TotalPrice = 0
                };
                await _unitOfWork.CartHeaderRepository.AddAsync(cartHeader);
                await _unitOfWork.SaveAsync();
            }

            var cartsDetails =
                await _unitOfWork.CartDetailsRepository.GetAllAsync(x => x.CartHeaderId == cartHeader.Id);

            var cartHeaderDto = _mapper.Map<CartHeaderDTO>(cartHeader);
            var cartDetailsDto = _mapper.Map<IEnumerable<CartDetailsDTO>>(cartsDetails);
            cartHeaderDto.CartDetailsDtos = cartDetailsDto;

            return new ResponseDTO()
            {
                Message = "Get cart successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = cartHeaderDto
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

    public async Task<ResponseDTO> AddToCart(ClaimsPrincipal User, AddToCartDTO addToCartDto)
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
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            var course = await _unitOfWork.CourseRepository.GetAsync(x => x.Id == addToCartDto.CourseId);
            if (course is null)
            {
                return new ResponseDTO()
                {
                    Message = "Course was not found",
                    IsSuccess = false,
                    StatusCode = 404,
                    Result = null
                };
            }

            var studentCourse =
                await _unitOfWork.StudentCourseRepository.GetAsync(x =>
                    x.StudentId == student.StudentId && x.CourseId == course.Id);
            if (studentCourse is not null)
            {
                return new ResponseDTO()
                {
                    Message = "You own this course already",
                    Result = null,
                    IsSuccess = false,
                    StatusCode = 400
                };
            }

            var courseVersion = await _unitOfWork.CourseVersionRepository.GetAsync(x => x.Id == course.CourseVersionId);
            if (courseVersion is null)
            {
                return new ResponseDTO()
                {
                    Message = "Course version was not found",
                    StatusCode = 404,
                    Result = null,
                    IsSuccess = false
                };
            }

            var cartHeader = await _unitOfWork.CartHeaderRepository.GetAsync(x => x.StudentId == student.StudentId);
            if (cartHeader is null)
            {
                cartHeader = new CartHeader()
                {
                    Id = Guid.NewGuid(),
                    StudentId = student.StudentId,
                    TotalPrice = 0
                };
                await _unitOfWork.CartHeaderRepository.AddAsync(cartHeader);
                await _unitOfWork.SaveAsync();
            }

            var cartDetails =
                await _unitOfWork.CartDetailsRepository.GetAsync
                (
                    filter: x => x.CartHeaderId == cartHeader.Id && x.CourseId == course.Id
                );

            if (cartDetails is not null)
            {
                return new ResponseDTO()
                {
                    IsSuccess = true,
                    Result = null,
                    StatusCode = 200,
                    Message = "Your course already exist in cart"
                };
            }

            cartDetails = new CartDetails()
            {
                Id = Guid.NewGuid(),
                CartHeaderId = cartHeader.Id,
                CourseId = course.Id,
                CoursePrice = courseVersion.Price,
                CourseTitle = courseVersion.Title
            };

            cartHeader.TotalPrice += cartDetails.CoursePrice;
            _unitOfWork.CartHeaderRepository.Update(cartHeader);

            await _unitOfWork.CartDetailsRepository.AddAsync(cartDetails);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                Message = "Add course to cart successfully",
                IsSuccess = true,
                StatusCode = 200,
                Result = addToCartDto
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

    public async Task<ResponseDTO> RemoveFromCart(ClaimsPrincipal User, Guid courseId)
    {
        try
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            var student = await _unitOfWork.StudentRepository.GetAsync
            (
                filter: x => x.UserId == userId
            );
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

            var cartHeader = await _unitOfWork.CartHeaderRepository.GetAsync
            (
                filter: x => x.StudentId == student.StudentId
            );
            if (cartHeader is null)
            {
                cartHeader = new CartHeader()
                {
                    Id = Guid.NewGuid(),
                    StudentId = student.StudentId,
                    TotalPrice = 0
                };
                await _unitOfWork.CartHeaderRepository.AddAsync(cartHeader);
                await _unitOfWork.SaveAsync();

                return new ResponseDTO()
                {
                    Message = "Your cart is empty",
                    StatusCode = 404,
                    Result = null,
                    IsSuccess = false
                };
            }

            var cartDetails = await _unitOfWork.CartDetailsRepository.GetAsync
            (
                filter: x => x.CourseId == courseId && x.CartHeaderId == cartHeader.Id
            );
            if (cartDetails is null)
            {
                return new ResponseDTO()
                {
                    Message = "Your course does not exist in cart",
                    StatusCode = 404,
                    Result = null,
                    IsSuccess = false
                };
            }

            cartHeader.TotalPrice -= cartDetails.CoursePrice;
            _unitOfWork.CartHeaderRepository.Update(cartHeader);

            _unitOfWork.CartDetailsRepository.Remove(cartDetails);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO()
            {
                Message = "Remove course in cart successfully",
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

    public Task<ResponseDTO> Checkout(ClaimsPrincipal User)
    {
        throw new NotImplementedException();
    }
}