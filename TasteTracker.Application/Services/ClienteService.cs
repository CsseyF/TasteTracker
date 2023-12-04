using TasteTracker.Application.Dtos;
using TasteTracker.Application.Dtos.ClienteDtos;
using TasteTracker.Application.Repositories.Interfaces;
using TasteTracker.Application.Services.Interfaces;
using TasteTracker.Core.Entities;

namespace TasteTracker.Application.Services
{
    public class ClienteService : Service<Cliente, FilterableRequest>, IClienteService
    {
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
