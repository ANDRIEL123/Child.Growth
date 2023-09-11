using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Child.Growth.src.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Child.Growth.src.Services.Implementations
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public object GenerateToken(string email)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var expiresIn = DateTime.Now.AddHours(1);

            var token = new JwtSecurityToken(
                claims: new[] { new Claim(ClaimTypes.Email, email) },
                expires: expiresIn,
                signingCredentials: credentials
            );

            return new
            {
                accessToken = $"Bearer {new JwtSecurityTokenHandler().WriteToken(token)}",
                expiresIn
            };
        }
    }
}