using HR.LMS.Application.Contracts.Identity;
using HR.LMS.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HR.LMS.API.Controller.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _auth;
        public AccountController(IAuthService auth)
        {
              _auth = auth;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResponse>> LOGIN(AuthencationRequest request)
        {
            return Ok(await _auth.Login(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> REGISTER(RegistrationRequest request)
        {
            return Ok(await _auth.Register(request));
        }
    }
}
