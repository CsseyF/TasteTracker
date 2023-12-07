using TasteTracker.Application.Dtos;
using TasteTracker.Core.Entities;

namespace TasteTracker.Application.Services.Interfaces
{
    public interface IClienteService : IService<Cliente, FilterableRequest>
    {

        public Task<Cliente> FindByEmailAsync(string email);
    }
}
