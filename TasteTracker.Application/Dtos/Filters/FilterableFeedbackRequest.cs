namespace TasteTracker.Application.Dtos.Filters
{
    public class FilterableFeedbackRequest : FilterableRequest
    {
        public int? Rating { get; set; }
    }
}
