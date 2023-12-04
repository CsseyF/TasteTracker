using Microsoft.EntityFrameworkCore;
using TasteTracker.Application.Dtos;
using TasteTracker.Application.Repositories.Interfaces;
using TasteTracker.Core.Entities;

namespace TasteTracker.Application.Repositories
{
    public class ClienteRepository : Repository<Cliente, FilterableRequest>,
        IRepository<Cliente, FilterableRequest>, IClienteRepository
    {

        public ClienteRepository(DbContext dbContext) : base(dbContext) { }
    }
}
