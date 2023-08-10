using API.dto.ProductsDto;
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
        public async Task<ActionResult> GetMyCart()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var cart = await _userRepository.GetMyCart(email!);

            return Ok(cart);
        }

        [HttpPost("SetCart")]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(CartDto), 200)]
        public async Task<ActionResult> AddMyCart(ProductAddDto newCart)
        {
            var email = User.FindFirstValue(ClaimTypes.Email)!;
            var cart = await _userRepository.AddCart(email, newCart);

            return Ok(cart);
        }

        [HttpGet("Profile")]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(UserDto), 200)]
        public async Task<ActionResult> GetProfile()
        {

            var email = User.FindFirstValue(ClaimTypes.Email)!;
            var user = await _userRepository.GetMe(email);

            return Ok(user);

        }

        [HttpDelete("DeleteCart")]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(CartDto), 200)]
        public async Task<ActionResult> DeleteCart([FromQuery] int cartId)
        {
            var email = User.FindFirstValue(ClaimTypes.Email)!;
            var deleteCart = await _userRepository.DeleteCart(email, cartId);

            if(deleteCart == null)
                return BadRequest("Cart Not Found");
            

            return Ok(deleteCart);
        }

        [HttpPost("AddPurchaseProduct")]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(ProductAddDto), 200)]
        public async Task<ActionResult> BuyProduct(ProductAddDto product)
        {
            var email = User.FindFirstValue(ClaimTypes.Email)!;
            var addPurchaseProduct = await _userRepository.BuyProduct(email, product);

            return Ok(addPurchaseProduct);
        }

        [HttpGet("GetPurchaseProduct")]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(IEnumerable<PurchaseProduct>), 200)]
        public async Task<ActionResult> GetBuyProduct()
        {
            var email = User.FindFirstValue(ClaimTypes.Email)!;
            var addPurchaseProduct = await _userRepository.GetBuyProduct(email);

            return Ok(addPurchaseProduct);
        }

        [HttpDelete("DeletePurchaseProduct")]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(ProductGetDto), 200)]
        public async Task<ActionResult> DeletePuchaseProduct([FromQuery] int productId)
        {

            var email = User.FindFirstValue(ClaimTypes.Email)!;
            var deletePurchaseProduct = await _userRepository.DeletePurchaseProduct(email, productId);

            if (deletePurchaseProduct == null)
                return BadRequest("Product Not Found");

            return Ok(deletePurchaseProduct);

        }


        [HttpPut("UpdateProfileImage")]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(UserDto), 200)]
        public async Task<ActionResult> UpdateProfileImage(string imageUrl)
        {
            var email = User.FindFirstValue(ClaimTypes.Email)!;
            var updateProfileImg = await _userRepository.UpdateProfileImage(email, imageUrl);

            if (updateProfileImg == null)
                return BadRequest("Error");

            return Ok(updateProfileImg);

        }

    }
}
