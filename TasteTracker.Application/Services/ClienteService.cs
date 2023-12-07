using TasteTracker.Application.Dtos;
using TasteTracker.Application.Repositories.Interfaces;
using TasteTracker.Application.Services.Interfaces;
using TasteTracker.Core.Entities;
using TasteTracker.Core.Exceptions;

namespace TasteTracker.Application.Services
{
    public class ClienteService : Service<Cliente, FilterableRequest>, IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IHashingService _hashingService;
        public ClienteService(IClienteRepository repository, IHashingService hashingService) : base(repository)
        {
            _repository = repository;
            _hashingService = hashingService;
        }

        public override async Task InsertAsync(Cliente entity, 
            CancellationToken cancellationToken)
        {
            try
            {
                var existence = _repository.CheckEmailExistance(entity.Email);

                if (existence)
                {
                    throw new AlreadyExistentException(nameof(entity.Email));
                }

                entity.Password = _hashingService.Hashpassword(entity.Password);
                await _repository.InsertAsync(entity, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cliente> FindByEmailAsync(string email)
        {
            var result = await _repository.FindByEmailAsync(email);
            if(result == null)
            {
                throw new EntityNotFoundException();
            }
            return result;
        }
    }
}
