using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWTImplementation
{
    public class AuthService: IAuthService
    {
        private readonly string secret;
        private readonly string expTime;
        private readonly string Email;
        public AuthService(IConfiguration configuration)
        {
            secret = configuration.GetSection("JWT").GetSection("clientSecret").Value;
            expTime= configuration.GetSection("JWT").GetSection("expirationInMinutes").Value;
            Email= configuration.GetSection("UserDetails").GetSection("email").Value;
        }

        public string GenerateSecurityToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);

            //Created a token descriptor.
            //Subject – New Claim identity
            //Expired – When it will be expired.
            //SigningCredentical – Private key +Algorithm

            //I am passing in an email to the ClaimsIdentity,  and storing that email in the token. 
            //You could pass in some a user object and store a lot more information by adding new claims.

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, Email),
                    //new Claim(ClaimTypes.Name, ""),
                    //new Claim(ClaimTypes.Role, ""),
                    //new Claim(ClaimTypes.DateOfBirth, ""),
                }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(expTime)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
