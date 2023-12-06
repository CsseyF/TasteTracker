using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteTracker.Application.Dtos;
using TasteTracker.Core.Entities;

namespace TasteTracker.Application.Repositories.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente, FilterableRequest>
    {
        public Task<Cliente>? FindByEmail(string email);
        public bool CheckEmailExistance(string email);
    }
}
