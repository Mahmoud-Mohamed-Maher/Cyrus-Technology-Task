using Cyrus_Technology_Task.Models;
using Cyrus_Technology_Task.Response;
using Cyrus_Technology_Task.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cyrus_Technology_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly UserManager<ApplicationUser> _userManager;


        public AuthController(IAuthService authService, UserManager<ApplicationUser> userManager)
        {
            _authService = authService;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<GeneralResponse> RegisterAsync([FromBody] RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {

                var result = await _authService.RegisterAsync(registerModel);

                if (result.IsAuthenticated)
                {

                    return new GeneralResponse
                    {
                        Data = result,
                        IsSuccess = true,
                        Message = "Authenticated",
                        Status=200
                    };
                }
                else
                {
                    return new GeneralResponse
                    {
                        Data = registerModel,
                        IsSuccess = false,
                        Status = 400,
                        Message = result.Message,
                    };
                }
            }
            else
            {
                return new GeneralResponse
                {
                    Data = ModelState,
                    IsSuccess = false,
                    Message = ModelState.ToString()
                };
            }
        }

        [HttpPost("Login")]
        public async Task<GeneralResponse> LoginAsync([FromBody] TokenRequestModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.LoginAsync(registerModel);
                ApplicationUser user = await _userManager.FindByEmailAsync(registerModel.Email);
                if (result.IsAuthenticated )
                {

                    return new GeneralResponse
                    {
                        Data = result,
                        IsSuccess = true,
                        Message = "Authenticated",
                        Token = result.Token
                    };
                }
                else
                {
                    return new GeneralResponse
                    {
                        Data = registerModel,
                        IsSuccess = false,
                        Message = result.Message
                    };
                }
            }
            else
            {
                return new GeneralResponse
                {
                    Data = ModelState,
                    IsSuccess = false,
                    Message = ModelState.ToString()

                };
            }
        }

    }
}
