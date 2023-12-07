using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TasteTracker.Application.Dtos;
using TasteTracker.Application.Dtos.ClienteDtos;
using TasteTracker.Application.Services.Interfaces;
using TasteTracker.Core.Entities;

namespace TasteTracker.API.Controllers
{
    [JwtAuthorize]
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> FindAllAsync(CancellationToken cancellationToken)
        {
            var result = await _service.FindAllAsync(new FilterableRequest(), cancellationToken);
            return Ok(result);
        }

        [HttpGet, Route("id")]
        public async Task<IActionResult> FindOneAsync([FromRoute]Guid id,
            CancellationToken cancellationToken)
        {
            var result = await _service.FindOneAsync(id, cancellationToken);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] CreateClienteDto request,
            CancellationToken cancellationToken)
        {
            Cliente entity = new()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
            };
            await _service.InsertAsync(entity, cancellationToken);
            return Created();
        }
    }
}
