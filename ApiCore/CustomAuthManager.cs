using ApiCore.Dto;
using DAL.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiCore
{
    public class CustomAuthManager
    {
        private readonly UserManager<User> _userManager;
        //private readonly SignInManager<User> _signInManager;
        public CustomAuthManager(UserManager<User> userManager) => _userManager = userManager;
        public async Task<string> LogginWithToken(LoginRequest userData, IConfiguration configuration)
        {
            // Validar existencia del usuario
            var user = await _userManager.FindByNameAsync(userData.UserName);
            if (user is null)
                throw new ArgumentNullException(nameof(userData)); // Username not valid
            if (!await _userManager.CheckPasswordAsync(user, userData.Password))
                throw new ArgumentException("Password didnt match");

            // Set claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.GivenName, user.UserName)//TODO: Add custom user params
            };

            var roles = await _userManager.GetRolesAsync(user);
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("Jwt:Key")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(720),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
        public async Task<IdentityResult> ChangePassword(PasswordChangeRequest userData)
        {
            // Validar existencia del usuario
            var user = await _userManager.FindByNameAsync(userData.UserName);
            if (user is null)
                throw new Exception($"User: {userData.UserName} not found ");
            return await _userManager.ChangePasswordAsync(user, userData.Password, userData.NewPassword);

        }
    }
}
