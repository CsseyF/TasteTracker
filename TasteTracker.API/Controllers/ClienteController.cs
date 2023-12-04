using Microsoft.AspNetCore.Mvc;
using TasteTracker.Application.Dtos.ClienteDtos;
using TasteTracker.Application.Services.Interfaces;
using TasteTracker.Core.Entities;

namespace TasteTracker.API.Controllers
{
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
        public async Task<IActionResult> FindAll(CancellationToken cancellationToken)
        {
            var result = await _service.FindAllAsync(null, cancellationToken);
            return Ok(result);
        }

        [HttpGet, Route("[id]")]
        public async Task<IActionResult> FindOne([FromRoute]Guid id,
            CancellationToken cancellationToken)
        {
            var result = await _service.FindOneAsync(id, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CreateClienteDto request,
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
