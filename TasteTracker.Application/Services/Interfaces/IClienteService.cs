using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteTracker.Application.Dtos;
using TasteTracker.Core.Entities;
using TasteTracker.Core.Entities.Interfaces;

namespace TasteTracker.Application.Services.Interfaces
{
    public interface IClienteService : IService<Cliente, FilterableRequest>
    {

        public Task<Cliente> FindByEmail(string email);
    }
}
