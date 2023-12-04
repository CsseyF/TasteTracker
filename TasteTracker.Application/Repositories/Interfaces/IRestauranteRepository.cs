using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteTracker.Application.Dtos;
using TasteTracker.Application.Dtos.Filters;
using TasteTracker.Core.Entities;

namespace TasteTracker.Application.Repositories.Interfaces
{
    public interface IRestauranteRepository : IRepository<Restaurante, FilterableRestauranteRequest>
    {
        Task<IEnumerable<Restaurante>> FindAllAsync
           (FilterableRestauranteRequest filter, CancellationToken cancellationToken);
    }
}
