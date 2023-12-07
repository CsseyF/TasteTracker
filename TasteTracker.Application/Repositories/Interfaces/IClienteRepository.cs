using TasteTracker.Application.Dtos;
using TasteTracker.Core.Entities;

namespace TasteTracker.Application.Repositories.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente, FilterableRequest>
    {
        public Task<Cliente>? FindByEmailAsync(string email);
        public bool CheckEmailExistance(string email);
    }
}
