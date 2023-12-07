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
