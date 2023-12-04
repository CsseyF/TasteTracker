using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteTracker.Application.Dtos;
using TasteTracker.Application.Dtos.Filters;
using TasteTracker.Application.Dtos.RestauranteDtos;
using TasteTracker.Core.Entities;

namespace TasteTracker.Application.Services.Interfaces
{
    public interface IRestauranteService : IService<Restaurante, FilterableRestauranteRequest>
    {
    }
}
