using BL.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class Authentication:ControllerBase
    {
        private readonly ILogger _logger;
        private readonly UserManager<DAL.Security.User> _userManager;
        private readonly IConfiguration _configuration;

        public Authentication(ILogger<Authentication> logger, IConfiguration configuration, UserManager<DAL.Security.User>? userManager)
        {
            _logger = logger;
            if(userManager == null) 
                throw new ArgumentNullException(nameof(userManager));
            _userManager = userManager;
            _configuration = configuration;
        }
        [HttpPost, AllowAnonymous, Route("login")]
        public async Task<object> Login([FromBody]LoginDto userData)
        {
            // Validar existencia del usuario
            var user = await _userManager.FindByNameAsync(userData.userName);
            if (user is null)
                return NotFound("Username not valid");
            if (!await _userManager.CheckPasswordAsync(user, userData.password))
                return BadRequest("Password didnt match");

            // Generamos un token según los claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.GivenName, user.UserName )//$"{user.FirstName} {user.LastName}")
            };

            var roles = await _userManager.GetRolesAsync(user);
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Jwt:Key")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(720),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            return Results.Ok(new
            {
                AccessToken = jwt
            });
        }
    }
}
public class LoginDto
{
    public string userName { get; set; }
    public string password { get; set; }
}