using Microsoft.EntityFrameworkCore;
using TasteTracker.Application.Dtos;
using TasteTracker.Application.Dtos.Filters;
using TasteTracker.Application.Repositories.Interfaces;
using TasteTracker.Core;
using TasteTracker.Core.Entities;

namespace TasteTracker.Application.Repositories
{
    public class FeedbackRepository : Repository<Feedback, FilterableFeedbackRequest>,
        IRepository<Feedback, FilterableFeedbackRequest>, IFeedbackRepository
    {
        public FeedbackRepository(TasteTrackerContext dbContext) : base(dbContext) { }

        override public async Task<IEnumerable<Feedback>> FindAllAsync
            (FilterableFeedbackRequest filter, CancellationToken cancellationToken)
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

            if (filter.Rating != null)
            {
                query = query.Where(records => records.Rating == filter.Rating);
            }

            query = query
                .Include(x => x.Cliente);

            return await query.ToListAsync(cancellationToken);
        }
    }
}
