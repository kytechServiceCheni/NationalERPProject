using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using National.Domain.Logic;
using National.Services.IServices;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace National.WebApi.Authentication
{
    public class ValidateToken
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;
        ILogger<ValidateToken> _logger;
        public ValidateToken(RequestDelegate next, IOptions<AppSettings> appSettings, ILogger<ValidateToken> logger)
        {
            _next = next;
            _appSettings = appSettings.Value;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context, IUserServices userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                await attachUserToContext(context, userService, token);

            await _next(context);
        }
        private async Task attachUserToContext(HttpContext context, IUserServices userService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);


                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
                _logger.LogInformation("jwt Token validate");
                // attach user to context on successful jwt validation
                context.Items["User"] = await userService.GetUserRecords(userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}
