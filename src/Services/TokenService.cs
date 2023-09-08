using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Child.Growth.src.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Child.Growth.src.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"])); // Substitua pela sua chave secreta
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Authentication:Issuer"],
                claims: new[] { new Claim(ClaimTypes.Name, username) },
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}