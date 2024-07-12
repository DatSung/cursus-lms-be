using System.Security.Claims;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.IService;

public interface ICartService
{
    Task<ResponseDTO> GetCart(ClaimsPrincipal User);
    Task<ResponseDTO> AddToCart(ClaimsPrincipal User, AddCartDetailsDTO addCartDetailsDto);
    Task<ResponseDTO> RemoveFromCart(ClaimsPrincipal User, Guid courseId);
}