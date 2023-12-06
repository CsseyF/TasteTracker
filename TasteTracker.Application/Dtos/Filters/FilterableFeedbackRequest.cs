using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasteTracker.Application.Dtos.Filters
{
    public class FilterableFeedbackRequest : FilterableRequest
    {
        public int? Rating { get; set; }
    }
}
