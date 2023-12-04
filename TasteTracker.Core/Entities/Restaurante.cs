using TasteTracker.Core.Entities.Interfaces;

namespace TasteTracker.Core.Entities
{
    public class Restaurante : IEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public List<Feedback>? Feedbacks { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
