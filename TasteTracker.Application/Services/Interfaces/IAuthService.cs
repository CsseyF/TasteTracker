using System.Security.Claims;
using TasteTracker.Application.Dtos.AuthDtos;

namespace TasteTracker.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> GenerateJwtTokenAsync(LoginDto request);
        ClaimsPrincipal ValidateJwtToken(string token);
    }
}
