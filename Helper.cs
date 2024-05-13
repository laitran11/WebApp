using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebApi.Models;

namespace WebApi
{
    public static class Helper
    {
        public static byte[] Hash(string plaintext)
        {
            HashAlgorithm algorithm = SHA512.Create();
            return algorithm.ComputeHash(Encoding.ASCII.GetBytes(plaintext));
        }
        public static string HashString(string plaintext)
        {
            byte[] bytes = Hash(plaintext);
            StringBuilder sb = new StringBuilder();
            foreach(byte item in bytes)
            {
                sb.Append(item.ToString("x2"));

            }
            return sb.ToString();
        }
        public static string CreateToken(Member obj)
        {
            byte[] key = Encoding.ASCII.GetBytes("aksdfjlaskfjaskofjadf");
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, obj.Username),
                    new Claim(ClaimTypes.NameIdentifier, obj.Id.ToString()),
                    new Claim(ClaimTypes.Email, obj.Email),
                    new Claim("Gender", obj.Gender ? "Male" : "Female")
                }),
                Expires = DateTime.UtcNow.AddHours(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = handler.CreateToken(descriptor);
            return handler.WriteToken(token);
        }
    }
}
