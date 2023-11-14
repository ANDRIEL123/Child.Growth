using System.Security.Cryptography;
using System.Text;
using Child.Growth.src.Services.Interfaces;

namespace Child.Growth.src.Services.Implementations
{
    public class CryptographyService : ICryptographyService
    {
        private readonly IConfiguration _configuration;

        public CryptographyService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CryptographyPassword(
            string password
        )
        {
            var bytesPassword = Encoding.UTF8.GetBytes(password);
            var bytesKey = Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]);

            using (var rfc2898 = new Rfc2898DeriveBytes(bytesPassword, bytesKey, 1000, HashAlgorithmName.SHA256))
            {
                var derivedKey = rfc2898.GetBytes(256 / 8);

                return Convert.ToBase64String(derivedKey);
            }
        }

        public string DecryptPassword(string base64)
        {
            return base64;
        }
    }
}