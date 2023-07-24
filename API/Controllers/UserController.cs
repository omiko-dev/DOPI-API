using API.Services.UsersServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet][Authorize]
        public async Task<ActionResult> GetMyInfo()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var cart = await _userRepository.GetMyCart(email);

            await Console.Out.WriteLineAsync(cart.ToString());
            return Ok(cart);
        }
    }
}
