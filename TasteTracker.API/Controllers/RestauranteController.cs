﻿using Microsoft.AspNetCore.Mvc;
using TasteTracker.Application.Dtos.ClienteDtos;
using TasteTracker.Application.Dtos.RestauranteDtos;
using TasteTracker.Application.Services.Interfaces;
using TasteTracker.Core.Entities;

namespace TasteTracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestauranteController : Controller
    {
        private readonly IRestauranteService _service;

        public RestauranteController(IRestauranteService service)
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
        public async Task<IActionResult> Insert([FromBody] CreateRestauranteDto request,
            CancellationToken cancellationToken)
        {
            Restaurante entity = new()
            {
                Name = request.Name,

            };
            await _service.InsertAsync(entity, cancellationToken);
            return Created();
        }

        public async Task<IActionResult> Update([FromBody] UpdateRestauranteDto request,
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
    }
}
