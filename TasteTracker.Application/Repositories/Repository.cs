using Microsoft.EntityFrameworkCore;
using TasteTracker.Application.Dtos;
using TasteTracker.Application.Repositories.Interfaces;
using TasteTracker.Core;
using TasteTracker.Core.Entities.Interfaces;

namespace TasteTracker.Application.Repositories
{
    public class Repository<T, U> : IRepository<T, U> where T : class, IEntity where U : FilterableRequest
    {
        private readonly TasteTrackerContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public Repository(TasteTrackerContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<T>();
        }

        public virtual async Task<T> FindOneAsync(
            Guid id, CancellationToken cancellationToken)
        {
            return await _dbSet.FirstOrDefaultAsync(record => record.Id == id, cancellationToken);
        }

        public virtual T FindOne(Guid id)
        {
            return _dbSet.FirstOrDefault(record => record.Id == id);
        }

        public virtual async Task<IEnumerable<T>> FindAllAsync
           (U filter, CancellationToken cancellationToken)
        {
            var query = _dbSet.Where(record => record.IsActive);

            if(filter.StartDate != DateTime.MinValue)
            {
                query = query.Where(records => records.CreatedAt >= filter.StartDate);
            }

            if(filter.FinalDate != DateTime.MinValue)
            {
                query = query.Where(records => records.CreatedAt <= filter.FinalDate);
            }

            return await query.ToListAsync(cancellationToken);
        }

        public virtual IEnumerable<T> FindAll(U filter)
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

            return query.ToList();
        }

        public virtual async Task InsertAsync(T entity,
           CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual void Insert(T entity)
        {
             _dbSet.Add(entity);
             _dbContext.SaveChanges();
        }

        public virtual async Task UpdateAsync(T entity,
           CancellationToken cancellationToken)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public virtual void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public virtual async Task DeleteAsync(T entity,
            CancellationToken cancellationToken)
        {
            entity.IsActive = false;
            await UpdateAsync(entity, cancellationToken);
        }

        public virtual void Delete(T entity)
        {
            entity.IsActive = false;
            Update(entity);
        }
    }
}
