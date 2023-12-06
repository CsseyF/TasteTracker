using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasteTracker.Application.Dtos.FeedbackDtos
{
    public class UpdateFeedbackDto
    {
        public Guid Id { get; set; }
        public string? Comment { get; set; }
        public int Rating { get; set; }
    }
}
