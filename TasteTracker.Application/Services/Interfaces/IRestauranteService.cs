using TasteTracker.Application.Dtos.Filters;
using TasteTracker.Core.Entities;

namespace TasteTracker.Application.Services.Interfaces
{
    public interface IRestauranteService : IService<Restaurante, FilterableRestauranteRequest>
    {
    }
}
