using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteTracker.Application.Dtos;
using TasteTracker.Application.Repositories.Interfaces;
using TasteTracker.Core.Entities;

namespace TasteTracker.Application.Repositories
{
    public class FeedbackRepository : Repository<Feedback, FilterableRequest>,
        IRepository<Feedback, FilterableRequest>, IFeedbackRepository
    {
        public FeedbackRepository(DbContext dbContext) : base(dbContext) { }
    }
}
