using Microsoft.EntityFrameworkCore;
using TasteTracker.Application.Dtos;
using TasteTracker.Application.Repositories.Interfaces;
using TasteTracker.Core;
using TasteTracker.Core.Entities;

namespace TasteTracker.Application.Repositories
{
    public class ClienteRepository : Repository<Cliente, FilterableRequest>,
        IRepository<Cliente, FilterableRequest>, IClienteRepository
    {

        public ClienteRepository(TasteTrackerContext dbContext) : base(dbContext) { }

        public async Task<Cliente>? FindByEmail(string email)
        {
            var result = _dbSet.FirstOrDefault(record => record.Email == email);
            return result;
        }

        public bool CheckEmailExistance(string email)
        {
            return _dbSet.Any(record => record.Email == email);
        }
    }
}
