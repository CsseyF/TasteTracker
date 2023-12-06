using Microsoft.AspNetCore.Mvc;
using TasteTracker.Application.Dtos.AuthDtos;
using TasteTracker.Application.Services.Interfaces;

namespace TasteTracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginDto request)
        {
            var jwt = await _authService.GenerateJwtToken(request);

            var options = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None
            };

            HttpContext.Response.Cookies.Append("jwtToken", jwt, options);

            return Ok(jwt);
        }
    }
}
