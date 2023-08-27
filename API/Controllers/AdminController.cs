using API.Models;
using API.Services.AdminService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;

        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpGet("GetAllUser")]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(User), 200)]
        public async Task<ActionResult> SeeAllUser()
        {

            return Ok(await this._adminRepository.GetAllUser());

        }

        [HttpDelete("RemoveUser")]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(User), 200)]
        public async Task<ActionResult> RemoveUser([FromQuery] int userId)
        {
            var removedUser = this._adminRepository.RemoveUser(userId);

            if (removedUser == null)
                return BadRequest("Not Found");

            return Ok(removedUser);

        }




    }
}
