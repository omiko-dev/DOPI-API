using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
