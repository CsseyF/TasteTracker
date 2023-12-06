using TasteTracker.Application.Dtos;
using TasteTracker.Application.Dtos.Filters;
using TasteTracker.Core.Entities;

namespace TasteTracker.Application.Repositories.Interfaces
{
    public interface IFeedbackRepository : IRepository<Feedback, FilterableFeedbackRequest>
    {
    }
}
