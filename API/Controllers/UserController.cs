using API.dto.UsersDto;
using API.Services.UsersServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet("GetCart")]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(CartDto), 200)]
        public async Task<ActionResult<CartDto>> GetMyCart()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var cart = _userRepository.GetMyCart(email);

            //await Console.Out.WriteLineAsync(cart.ToString());
            return Ok(cart.Result);
        }

        [HttpPost("SetCart")]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(CartDto), 200)]
        public async Task<ActionResult> AddMyCart(CartDto newCart)
        {
            var email = User.FindFirstValue(ClaimTypes.Email)!;
            var cart = await _userRepository.AddCart(email, newCart);

            return Ok(cart);
        }

        [HttpGet("Profile")]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(User), 200)]
        public async Task<ActionResult> GetProfile()
        {

            var email = User.FindFirstValue(ClaimTypes.Email)!;
            var user = await _userRepository.GetMe(email);

            return Ok(user);

        }

        [HttpDelete()]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(CartDto), 200)]
        public async Task<ActionResult> DeleteCart([FromQuery] int cartId)
        {
            var email = User.FindFirstValue(ClaimTypes.Email)!;
            var deleteCart = await _userRepository.DeleteCart(email, cartId);

            return Ok(deleteCart);
        }

    }
}
