using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TasteTracker.Application.Dtos.Filters;
using TasteTracker.Application.Dtos.RestauranteDtos;
using TasteTracker.Application.Repositories;
using TasteTracker.Application.Repositories.Interfaces;
using TasteTracker.Application.Services.Interfaces;
using TasteTracker.Core.Entities;
using TasteTracker.Core.Exceptions;

namespace TasteTracker.Application.Services
{
    public class RestauranteService : Service<Restaurante, FilterableRestauranteRequest>, IRestauranteService
    {
        private readonly IRestauranteRepository _restauranteRepository;
        private readonly IAuthService _authService;
        private readonly IClienteService _clienteService;
        public RestauranteService(IRestauranteRepository restauranteRepository, IAuthService authService, IClienteService clienteService) : base(restauranteRepository)
        {
            _restauranteRepository = restauranteRepository;
            _authService = authService;
            _clienteService = clienteService;
        }

        public override async Task<Restaurante> FindOneAsync(
            Guid id, CancellationToken cancellationToken)
        {
            var entity = await _restauranteRepository
                .FindOneAsync(id, cancellationToken);

            if(entity is null)
            {
                throw new EntityNotFoundException();
            }

            return entity;
        }

        public override async Task<IEnumerable<Restaurante>> FindAllAsync(
            FilterableRestauranteRequest filter, CancellationToken cancellationToken)
        {
            var query = await _restauranteRepository
                .FindAllAsync(filter, cancellationToken);

            return query;
        }

        public override async Task InsertAsync(
            Restaurante entity, CancellationToken cancellationToken)
        {
            try
            {
                await _restauranteRepository.InsertAsync(entity, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override async Task UpdateAsync(
            Restaurante entity, CancellationToken cancellationToken)
        {
            var oldEntity = await _restauranteRepository
                .FindOneAsync(entity.Id, cancellationToken);

            if(oldEntity is null)
            {
                throw new EntityNotFoundException();
            }
            
            oldEntity.Name = entity.Name;

            await _restauranteRepository
                .UpdateAsync(oldEntity,cancellationToken);
        }

        public override async Task DeleteAsync(Guid id, string jwt,
                CancellationToken cancellationToken)
        {
            var claims = _authService.ValidateJwtToken(jwt);
            var emailClaims = claims.FindFirst(ClaimTypes.Name)?.Value;

            if (string.IsNullOrWhiteSpace(emailClaims))
            {
                throw new UnauthorizedAccessException();
            }

            var cliente = await _clienteService.FindByEmail(emailClaims);
            var entity = await _restauranteRepository.FindOneAsync(id, cancellationToken);

            if(entity == null)
            {
                throw new EntityNotFoundException();
            }

            if(entity.ClienteId != cliente.Id)
            {
                throw new UnauthorizedAccessException();
            }

            await _restauranteRepository.DeleteAsync(entity, cancellationToken);
        }
    }
}
