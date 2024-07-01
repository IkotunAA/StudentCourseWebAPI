
using Microsoft.AspNetCore.Mvc;
using WebAPIBatch20.Services.Interfaces;
using static WebAPIBatch20.Models.LoginModels;
using static WebAPIBatch20.Models.UserModels;

namespace WebAPIBatch20.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register(CreateUserRequest request)
        {
            var resp = _userService.Register(request);
            return Ok(resp);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var resp = _userService.Login(request);
            return Ok(resp);
        }
    }
}
