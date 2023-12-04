using System;
using System.Collections.Generic;
using System.Linq;
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
        public RestauranteService(IRestauranteRepository restauranteRepository) : base(restauranteRepository)
        {
            _restauranteRepository = restauranteRepository;
        }

        public override async Task<Restaurante> FindOneAsync(
            Guid id, CancellationToken cancellationToken)
        {
            var entity = await _restauranteRepository
                .FindOneAsync(id, cancellationToken);

            if(entity is null)
            {
                throw new NotFoundException();
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
                throw new NotFoundException();
            }
            
            oldEntity.Name = entity.Name;

            await _restauranteRepository
                .UpdateAsync(oldEntity,cancellationToken);
        }
    }
}
