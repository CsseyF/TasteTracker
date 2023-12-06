using Microsoft.EntityFrameworkCore;
using TasteTracker.Application.Dtos.Filters;
using TasteTracker.Application.Repositories.Interfaces;
using TasteTracker.Core;
using TasteTracker.Core.Entities;

namespace TasteTracker.Application.Repositories
{
    public class RestauranteRepository : Repository<Restaurante, FilterableRestauranteRequest>,
        IRepository<Restaurante, FilterableRestauranteRequest>, IRestauranteRepository
    {
        public RestauranteRepository(TasteTrackerContext dbContext) : base(dbContext) { }

        override public async Task<IEnumerable<Restaurante>> FindAllAsync
           (FilterableRestauranteRequest filter, CancellationToken cancellationToken)
        {
            var query = _dbSet.Where(record => record.IsActive);

            if (filter.StartDate != DateTime.MinValue)
            {
                query = query.Where(records => records.CreatedAt >= filter.StartDate);
            }

            if (filter.FinalDate != DateTime.MinValue)
            {
                query = query.Where(records => records.CreatedAt <= filter.FinalDate);
            }

            if(!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(records => EF.Functions.Like(records.Name, filter.Name));
            }

            return await query.ToListAsync(cancellationToken);
        }
    }
}
