using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using online_medical_services.Entities;
using online_medical_services.Models;

namespace online_medical_services.Helpers
{
    public class SessionManagement
    {
        public TokenResponseModel GenerateAccessToken(int userId, string email)
        {
            TokenResponseModel tokenResponseModel = new TokenResponseModel();
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var appSecret = config["AppSecret"];
            DateTime TokenExpiry = DateTime.Now.AddDays(1);
            DateTime TokenValidFrom = DateTime.Now;
            if (appSecret != null)
            {
                var key = Encoding.ASCII.GetBytes(appSecret);
                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                {
                  new Claim(ClaimTypes.Name, userId.ToString()),
                  new Claim(ClaimTypes.Email, email.ToString()),
                  new Claim(ClaimTypes.AuthenticationMethod, "OP_Auth"),
                   new Claim(ClaimTypes.NameIdentifier, config["Issuer"])
                }),
                    Expires = TokenExpiry,
                    SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature)
                };
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                JwtSecurityToken token = handler.CreateJwtSecurityToken(tokenDescriptor);
                tokenResponseModel = new TokenResponseModel
                {
                    AccessToken= handler.WriteToken(token),
                    Issuer= config["Issuer"],
                    ValidTo= TokenExpiry,
                    ValidFrom= TokenValidFrom,
                };
            }

            return tokenResponseModel;
        }
    }
}
