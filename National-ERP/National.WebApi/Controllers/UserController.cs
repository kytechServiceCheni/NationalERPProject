using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using National.Services.IServices;
using National.Services.ServiceRequest;
using National.WebApi.Authorization;

namespace National.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
       private readonly IUserServices _Iuser;
        public UserController(ILogger<UserController> logger, IUserServices Iuser)
        {
            _logger = logger;
            _Iuser = Iuser;
        }
        [Authorize]
        [HttpGet("UserRecords")]
        public async Task<IActionResult> GetUserRecords(int userId)
        {
            try
            {
                _logger.LogInformation("Login start");
                var user = await _Iuser.GetUserRecords(userId);
                return Ok(user);

            }
            catch (Exception ex)
            {
                _logger.LogError("Error:" + ex.Message);
                return Ok("Error:" + ex.Message);

            }

        }
        [HttpPost("auth/signin")]
        public async Task<IActionResult> Login([FromBody] UserRequest loginUser)
        {
            try
            {
                _logger.LogInformation("Login start");
                var user = await _Iuser.Authenticate(loginUser);
                return Ok(user);

            }
            catch (Exception ex)
            {
                _logger.LogError("Error:" + ex.Message);
                return Ok("Error:" + ex.Message);

            }

        }
       // [Authorize]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRequest user)
        {
            try
            {
                _logger.LogInformation("Create new user");
               var meaggeShow = await _Iuser.RegisterUser(user);            
                return Ok(meaggeShow);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error:" + ex.Message);
                return Ok("Error:" + ex.Message);

            }
        }
    }
}
