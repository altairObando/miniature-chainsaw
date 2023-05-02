using DAL.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
                return Results.BadRequest(ex);
            }
        }
        [HttpPut]
        public async Task<object> ChangePassword([FromBody] Dto.PasswordChangeRequest userData)
        {
            // Validar existencia del usuario
            var response = await new CustomAuthManager(_userManager).ChangePassword(userData);
            return response.Succeeded ? Results.Ok(new { message = "Password updated" }) : Results.BadRequest(response.Errors.Single());
        }
    }
}