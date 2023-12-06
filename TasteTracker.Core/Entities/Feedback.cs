using System.ComponentModel.DataAnnotations;
using TasteTracker.Core.Entities.Interfaces;

namespace TasteTracker.Core.Entities
{
    public class Feedback : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Restaurante? Restaurante { get; set; }
        public Guid RestauranteId { get; set; }
        public Cliente? Cliente { get; set; }
        public Guid ClienteId { get; set; }
        public string? Comment { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
