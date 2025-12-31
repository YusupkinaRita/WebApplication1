using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController(IAccountService accountService ) : ControllerBase
    {

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            await accountService.RegisterAsync(request.Login ,request.UserName, request.Password);
            return Ok();

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest lrequest)
        {
            var token = await accountService.LoginAsync(lrequest.Login, lrequest.Password);
            return Ok(token);


        }
    }
}
