using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TasteTracker.Application.Dtos.AuthDtos;

namespace TasteTracker.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> GenerateJwtToken(LoginDto request);
        ClaimsPrincipal ValidateJwtToken(string token);
    }
}
