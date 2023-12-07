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

        [HttpGet]
        public async Task<IActionResult> FindAllAsync([FromQuery]FilterableRestauranteRequest request, CancellationToken cancellationToken)
        {
            var result = await _service.FindAllAsync(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindOneAsync([FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            var result = await _service.FindOneAsync(id, cancellationToken);
            return Ok(result);
        }

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var token = HttpContext.Request.Cookies["jwtToken"];
            await _service.DeleteAsync(id, token, cancellationToken);
            return NoContent();
        }
    }
}
