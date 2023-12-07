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

        /// <summary>
        /// Retorna todos os clientes ativos, requisição filtravel por data e nome de cliente.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> FindAllAsync(CancellationToken cancellationToken)
        {
            var result = await _service.FindAllAsync(new FilterableRequest(), cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Retorna um cliente especifico com base em seu identificador.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet, Route("id")]
        public async Task<IActionResult> FindOneAsync([FromRoute]Guid id,
            CancellationToken cancellationToken)
        {
            var result = await _service.FindOneAsync(id, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Adiciona novo cliente na base de dados.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
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
