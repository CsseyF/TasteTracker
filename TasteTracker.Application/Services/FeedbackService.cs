using System.Security.Claims;
using TasteTracker.Application.Dtos.Filters;
using TasteTracker.Application.Repositories.Interfaces;
using TasteTracker.Application.Services.Interfaces;
using TasteTracker.Core.Entities;
using TasteTracker.Core.Exceptions;

namespace TasteTracker.Application.Services
{
    public class FeedbackService : Service<Feedback, FilterableFeedbackRequest>, IFeedbackService
    {
        private readonly IFeedbackRepository _repository;
        private readonly IAuthService _authService;
        private readonly IClienteService _clienteService;
        private readonly IRestauranteService _restauranteService;

        public FeedbackService(
            IFeedbackRepository repository,
            IAuthService authService,
            IClienteService clienteService,
            IRestauranteService restauranteService) : base(repository)
        {
            _repository = repository;
            _authService = authService;
            _clienteService = clienteService;
            _restauranteService = restauranteService;

        }

        public override async Task<IEnumerable<Feedback>> FindAllAsync(
       FilterableFeedbackRequest filter, CancellationToken cancellationToken)
        {
            var query = await _repository
                .FindAllAsync(filter, cancellationToken);

            return query;
        }

        public override async Task InsertAsync(Feedback entity, CancellationToken cancellationToken, string? jwt)
        {
            try
            {
                var claims = _authService.ValidateJwtToken(jwt);
                var emailClaims = claims.FindFirst(ClaimTypes.Name)?.Value;

                if (string.IsNullOrWhiteSpace(emailClaims))
                {
                    throw new UnauthorizedAccessException();
                }

                var cliente = await _clienteService.FindByEmail(emailClaims);

                entity.ClienteId = cliente.Id;

                var restaurante = _restauranteService.FindOne(entity.RestauranteId);

                if (restaurante == null)
                {
                    throw new EntityNotFoundException(nameof(Restaurante));
                }

                await _repository.InsertAsync(entity, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override async Task UpdateAsync(Feedback entity,
            CancellationToken cancellationToken, string jwt)
        {
            var claims = _authService.ValidateJwtToken(jwt);
            var emailClaims = claims.FindFirst(ClaimTypes.Name)?.Value;

            if (string.IsNullOrWhiteSpace(emailClaims))
            {
                throw new UnauthorizedAccessException();
            }

            var cliente = await _clienteService.FindByEmail(emailClaims);
            var oldEntity = await _repository.FindOneAsync(entity.Id, cancellationToken);

            if (oldEntity.ClienteId != cliente.Id)
            {
                throw new UnauthorizedAccessException();
            }

            oldEntity.Comment = entity.Comment;
            oldEntity.Rating = entity.Rating;

            await _repository.UpdateAsync(oldEntity, cancellationToken);
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
            var entity = await _repository.FindOneAsync(id, cancellationToken);


            if (entity == null)
            {
                throw new EntityNotFoundException();
            }

            if (entity.ClienteId != cliente.Id)
            {
                throw new UnauthorizedAccessException();
            }
            await _repository.DeleteAsync(entity, cancellationToken);
        }
    }
}
