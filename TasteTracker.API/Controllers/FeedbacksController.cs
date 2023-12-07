using Microsoft.AspNetCore.Mvc;
using TasteTracker.Application.Dtos.ClienteDtos;
using TasteTracker.Application.Dtos.FeedbackDtos;
using TasteTracker.Application.Dtos.Filters;
using TasteTracker.Application.Services.Interfaces;
using TasteTracker.Core.Entities;

namespace TasteTracker.API.Controllers
{
    [JwtAuthorize]
    [ApiController]
    [Route("[controller]")]
    public class FeedbacksController : Controller
    {
        private readonly IFeedbackService _service;
        public FeedbacksController(IFeedbackService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todos os feedbacks ativos, requisição filtravel por data e avaliação.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> FindAllAsync([FromQuery] FilterableFeedbackRequest request, CancellationToken cancellationToken)
        {
            var result = await _service.FindAllAsync(request, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Retorna um feedback especifico com base em seu identificador.
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
        /// Adiciona nova avaliação na base de dados.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] CreateFeedbackDto request,
            CancellationToken cancellationToken)
        {

            var token = HttpContext.Request.Cookies["jwtToken"];
            Feedback entity = new()
            {
                RestauranteId = request.RestauranteId,
                Comment = request.Comment,
                Rating = request.Rating,
                TipoFeedback = request.TipoFeedaback,
            };
            await _service.InsertAsync(entity, cancellationToken, token);
            return Created();
        }

        /// <summary>
        /// Edita uma avaliação já existente na base de dados (Limitado a quem o criou).
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateFeedbackDto request,
            CancellationToken cancellationToken)
        {
            var token = HttpContext.Request.Cookies["jwtToken"];
            Feedback entity = new()
            {
                Id = request.Id,
                Comment = request.Comment,
                Rating = request.Rating,
            };

            await _service.UpdateAsync(entity, cancellationToken, token);
            return NoContent();
        }

        /// <summary>
        /// Desativa uma avaliação existente da base da dados (Limitado a quem o criou).
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
