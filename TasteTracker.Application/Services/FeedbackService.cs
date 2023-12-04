using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteTracker.Application.Dtos;
using TasteTracker.Application.Repositories;
using TasteTracker.Application.Repositories.Interfaces;
using TasteTracker.Application.Services.Interfaces;
using TasteTracker.Core.Entities;

namespace TasteTracker.Application.Services
{
    public class FeedbackService : Service<Feedback, FilterableRequest>, IFeedbackService
    {
        private readonly IFeedbackRepository _repository;

        public FeedbackService(IFeedbackRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
