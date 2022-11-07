using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using National.Domain.Logic.DTO;
using National.Domain.Logic.IRepository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace National.Domain.Logic.Repository
{
    public class TokenRepository: ITokenRepository
    {
        private readonly AppSettings _appSettings;
        private readonly expiresToken _expires;
        public TokenRepository(IOptions<AppSettings> appSettings, IOptions<expiresToken> expires)
        {
            _appSettings = appSettings.Value;
            _expires = expires.Value;
        }
        public string GenerateJwtToken(UserDto user)
        {
            // generate token that is valid for 7 days
            IdentityModelEventSource.ShowPII = true;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            // var key = Encoding.ASCII.GetBytes("emperorIndia1234765434445555552345555555555sdddd");
            var expiresTime = _expires.minutes;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(expiresTime),
                // Expires= DateTime.UtcNow.AddMinutes(40),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
