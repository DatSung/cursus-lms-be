using System.Security.Claims;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;

namespace Cursus.LMS.Service.Service;

public class CartService : ICartService
{
    private readonly IUnitOfWork _unitOfWork;

    public CartService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<ResponseDTO> GetCart(ClaimsPrincipal User)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> AddToCart(ClaimsPrincipal User, AddCartDetailsDTO addCartDetailsDto)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> RemoveFromCart(ClaimsPrincipal User, Guid courseId)
    {
        throw new NotImplementedException();
    }
}