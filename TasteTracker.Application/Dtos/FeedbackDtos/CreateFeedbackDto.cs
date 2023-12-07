namespace TasteTracker.Application.Dtos.FeedbackDtos
{
    public class CreateFeedbackDto
    {
        public Guid RestauranteId { get; set; }
        public string? Comment { get; set; }
        public int Rating { get; set; }
    }
}
