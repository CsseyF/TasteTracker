using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;
using TasteTracker.Application.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using TasteTracker.Application.Dtos.AuthDtos;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;

namespace TasteTracker.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IClienteService _clienteService;
        private readonly IHashingService _hashingService;

        public AuthService(IConfiguration configuration, IClienteService clienteService, IHashingService hashingService)
        {
            _configuration = configuration;
            _clienteService = clienteService;
            _hashingService = hashingService;

        }
        public async Task<string> GenerateJwtToken(LoginDto request)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var entity = await _clienteService.FindByEmail(request.Email);
            var hashedPassword = _hashingService.Hashpassword(request.Password);

            if(entity.Password != hashedPassword)
            {
                throw new UnauthorizedAccessException();
            }

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                new[] { new Claim(ClaimTypes.Name, entity.Email) },
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public ClaimsPrincipal ValidateJwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]);

            try
            {
                SecurityToken validatedToken;
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidAudience = _configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                }, out validatedToken);

                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    return principal as ClaimsPrincipal;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
