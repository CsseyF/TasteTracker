using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TasteTracker.Application.Dtos.ClienteDtos;
using TasteTracker.Application.Dtos.Filters;
using TasteTracker.Application.Dtos.RestauranteDtos;
using TasteTracker.Application.Services.Interfaces;
using TasteTracker.Core.Entities;

namespace TasteTracker.API.Controllers
{
    [JwtAuthorize]
    [ApiController]
    [Route("[controller]")]
    public class RestaurantesController : Controller
    {
        private readonly IRestauranteService _service;

        public RestaurantesController(IRestauranteService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todos os restaurantes ativos, requisição filtravel por data e nome do restaurante.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> FindAllAsync([FromQuery]FilterableRestauranteRequest request, CancellationToken cancellationToken)
        {
            var result = await _service.FindAllAsync(request, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Retorna um restaurante especifico com base em seu identificador.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> FindOneAsync([FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            var result = await _service.FindOneAsync(id, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Adiciona novo restaurant na base de dados.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] CreateRestauranteDto request,
            CancellationToken cancellationToken)
        {
            Restaurante entity = new()
            {
                Name = request.Name,

            };
            await _service.InsertAsync(entity, cancellationToken);
            return Created();
        }

        /// <summary>
        /// Edita um restaurante já existente na base de dados(Limitado a quem o criou).
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateRestauranteDto request,
            CancellationToken cancellationToken)
        {
            Restaurante entity = new()
            {
                Id = request.Id,
                Name = request.Name,
            };

            await _service.UpdateAsync(entity, cancellationToken);
            return Created();
        }

        /// <summary>
        /// Desativa um restaurante existente da base da dados (Limitado a quem o criou).
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var token = HttpContext.Request.Cookies["jwtToken"];
            await _service.DeleteAsync(id, token, cancellationToken);
            return NoContent();
        }
    }
}
