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

        [HttpGet]
        public async Task<IActionResult> FindAllAsync([FromQuery] FilterableFeedbackRequest request, CancellationToken cancellationToken)
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
        public async Task<IActionResult> InsertAsync([FromBody] CreateFeedbackDto request,
            CancellationToken cancellationToken)
        {

            var token = HttpContext.Request.Cookies["jwtToken"];
            Feedback entity = new()
            {
                RestauranteId = request.RestauranteId,
                Comment = request.Comment,
                Rating = request.Rating,
            };
            await _service.InsertAsync(entity, cancellationToken, token);
            return Created();
        }

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var token = HttpContext.Request.Cookies["jwtToken"];
            await _service.DeleteAsync(id, token, cancellationToken);
            return NoContent();
        }
    }
}
