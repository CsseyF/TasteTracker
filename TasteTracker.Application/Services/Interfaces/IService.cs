using TasteTracker.Application.Dtos;
using TasteTracker.Core.Entities.Interfaces;

namespace TasteTracker.Application.Services.Interfaces
{
    public interface IService<T, U> where T : class, IEntity where U : FilterableRequest
    {
        Task<T> FindOneAsync(Guid id, CancellationToken cancellationToken);
        T FindOne(Guid id);
        Task<IEnumerable<T>> FindAllAsync(U filter, CancellationToken cancellationToken);
        IEnumerable<T> FindAll(U filter);
        Task InsertAsync(T entity, CancellationToken cancellationToken);
        void Insert(T entity);
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
        void Update(T entity);
    }
}
