using LogixTest.Domain.Dto.Error;
using LogixTest.Domain.Dto.User.Input;
using LogixTest.Services;
using LogixTest.Shared.Constants;
using Microsoft.AspNetCore.Mvc;

namespace LogixTest.Controllers
{
    [Route("api/v1/user_profile")]
    [ApiVersion("1.0")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto input)
        {
            var data = await _userProfileService.Login(input);

            if (data == LoginConstants.UserNotFound)
            {
                return BadRequest(new ErrorDto
                {
                    Code = "Error",
                    Message = LoginConstants.UserNotFound
                });
            }

            if (data == LoginConstants.WrongPassword)
            {
                return BadRequest(new ErrorDto
                {
                    Code = "Error",
                    Message = LoginConstants.WrongPassword
                });
            }

            return Ok(new ErrorDto{Code = "Ok", Message = "Login Successful", Data = data });
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto input)
        {
            await _userProfileService.Register(input);

            return Ok(new ErrorDto { Code = "Ok", Message = "Register Successful"});
        }

    }
}
