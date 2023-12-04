using TasteTracker.Application.Dtos;
using TasteTracker.Core.Entities;

namespace TasteTracker.Application.Services.Interfaces
{
    public interface IFeedbackService : IService<Feedback, FilterableRequest>
    {
    }
}
