using TasteTracker.Application.Dtos;
using TasteTracker.Application.Repositories.Interfaces;
using TasteTracker.Application.Services.Interfaces;
using TasteTracker.Core.Entities.Interfaces;

namespace TasteTracker.Application.Services
{
    public class Service<T, U> : IService<T, U> where T : class, IEntity where U : FilterableRequest
    {
        private readonly IRepository<T, U> _repository;
        public Service(IRepository<T, U> repository)
        {
            _repository = repository;

        }
        public virtual async Task<T> FindOneAsync(
            Guid id, CancellationToken cancellationToken)
        {
            return await _repository.FindOneAsync(id, cancellationToken);
        }

        public virtual T FindOne(Guid id)
        {
            return _repository.FindOne(id);
        }

        public virtual async Task<IEnumerable<T>> FindAllAsync
           (U filter, CancellationToken cancellationToken)
        {
            var query = await _repository.FindAllAsync(filter, cancellationToken);
            return query;
        }

        public virtual IEnumerable<T> FindAll(U filter)
        {
            var query = _repository.FindAll(filter);

            return query.ToList();
        }

        public virtual async Task InsertAsync(T entity,
           CancellationToken cancellationToken)
        {
            await _repository.InsertAsync(entity, cancellationToken);
        }

        public virtual void Insert(T entity)
        {
            _repository.Insert(entity);
        }

        public virtual async Task UpdateAsync(T entity,
           CancellationToken cancellationToken)
        {
            await _repository.UpdateAsync(entity, cancellationToken);
        }

        public virtual void Update(T entity)
        {
            _repository.Update(entity);
        }
    }
}
