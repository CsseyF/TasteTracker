using TasteTracker.Application.Dtos;
using TasteTracker.Core.Entities;

namespace TasteTracker.Application.Repositories.Interfaces
{
    public interface IFeedbackRepository : IRepository<Feedback, FilterableRequest>
    {
    }
}
