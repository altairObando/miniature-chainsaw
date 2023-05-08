using DAL.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace ApiCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class Authentication : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public Authentication(ILogger<Authentication> logger, IConfiguration configuration, UserManager<User>? userManager)
        {
            _logger = logger;
            if (userManager == null)
                throw new ArgumentNullException(nameof(userManager));
            _userManager = userManager;
            _configuration = configuration;
        }
        [HttpPost, AllowAnonymous]
        public async Task<object> Login([FromBody] Dto.LoginRequest userData)
        {
            try
            {
                _logger.LogInformation($"Logging for user {userData.UserName}");
                var jwt = await new CustomAuthManager( _userManager ).LogginWithToken(userData, _configuration);
                return Results.Ok(new
                {
                    AccessToken = jwt
                });
            }
            catch (Exception ex)
            {
                Results.StatusCode(403);
                return Results.Unauthorized();
            }
        }
        [HttpPut]
        public async Task<object> ChangePassword([FromBody] Dto.PasswordChangeRequest userData)
        {
            // Validar existencia del usuario
            var response = await new CustomAuthManager(_userManager).ChangePassword(userData);
            return response.Succeeded ? Results.Ok(new { message = "Password updated" }) : Results.BadRequest(response.Errors.Single());
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<bool> CreateSuperUser()
        {
            if (await _userManager.FindByNameAsync("altair") != null)
                return true;

            var created = await _userManager.CreateAsync(new User { Email ="pxnfilo@gmail.com", UserName="altair", PhoneNumber="50578553482", PhoneNumberConfirmed = true });
            if (!created.Succeeded)
                return false;
            var user = await _userManager.FindByNameAsync("altair");
            var result = await _userManager.AddPasswordAsync(user, "#Gyn20201218*#");
            if(!result.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                return false;
            }
            return true;
        }
    }
}