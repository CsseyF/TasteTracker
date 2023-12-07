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

        /// <summary>
        /// Request para autenticação de usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody]LoginDto request)
        {
            var jwt = await _authService.GenerateJwtTokenAsync(request);

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
