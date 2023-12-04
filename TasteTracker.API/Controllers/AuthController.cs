using Microsoft.AspNetCore.Mvc;
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
    }
}
