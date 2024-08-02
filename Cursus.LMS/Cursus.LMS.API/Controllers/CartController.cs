using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cursus.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = StaticUserRoles.Student)]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetCart()
        {
            var responseDto = await _cartService.GetCart(User);
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("details")]
        public async Task<ActionResult<ResponseDTO>> AddToCart([FromBody] AddToCartDTO addToCartDto)
        {
            var responseDto = await _cartService.AddToCart
            (
                User,
                addToCartDto
            );
            return StatusCode(responseDto.StatusCode, responseDto);
        }

        [HttpDelete]
        [Route("details/{detailsId:Guid}")]
        public async Task<ActionResult<ResponseDTO>> RemoveFromCart([FromRoute] Guid cartDetailsId)
        {
            var responseDto = await _cartService.RemoveFromCart
            (
                User,
                cartDetailsId
            );
            return StatusCode(responseDto.StatusCode, responseDto);
        }
    }
}