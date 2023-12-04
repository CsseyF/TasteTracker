using Microsoft.AspNetCore.Mvc;
using TasteTracker.Application.Dtos.ClienteDtos;
using TasteTracker.Application.Dtos.FeedbackDtos;
using TasteTracker.Application.Services.Interfaces;
using TasteTracker.Core.Entities;

namespace TasteTracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _service;
        public FeedbackController(IFeedbackService service)
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
        public async Task<IActionResult> FindOne([FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            var result = await _service.FindOneAsync(id, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CreateFeedbackDto request,
            CancellationToken cancellationToken)
        {
            Feedback entity = new()
            {
                ClienteId = request.ClienteId,
                RestauranteId = request.RestauranteId,
                Comment = request.Comment,
                Rating = request.Rating,
            };
            await _service.InsertAsync(entity, cancellationToken);
            return Created();
        }
    }
}
