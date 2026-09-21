using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SportsStore.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SportsStore.WebUI.Controllers
{
    // Tạo một class DTO để nhận dữ liệu đăng nhập
    public class LoginModel
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class AccountApiController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _config;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel
loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.Username);
            if (user != null)
            {
                var result = await
                _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);
                if (result.Succeeded)
                {
                    var token = GenerateJwtToken(user);
                    return Ok(new { token }); // Trả về token cho client
                }
            }
            return Unauthorized(); // Nếu đăng nhập thất bại
        }

        private string GenerateJwtToken(AppUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey,
            SecurityAlgorithms.HmacSha256);
            // Thêm các "claims" - thông tin về user vào token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                // Thêm các claims khác nếu cần, ví dụ role
            };

            var token = new JwtSecurityToken
            (

                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(120), // Thời gian hết hạn
                signingCredentials: credentials
 
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

