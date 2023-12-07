namespace TasteTracker.Application.Dtos.FeedbackDtos
{
    public class UpdateFeedbackDto
    {
        public Guid Id { get; set; }
        public string? Comment { get; set; }
        public int Rating { get; set; }
    }
}
