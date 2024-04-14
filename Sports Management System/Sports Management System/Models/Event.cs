using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sports_Management_System.Models
{
    public class Event
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid GameId { get; set; }
        public Game Game { get; set; }

        [Required]
        [DisplayName("Feature Event")]
        public string FeatureEvent { get; set; }

        [Required]
        [DisplayName("Event Venue")]
        public string EventVenue { get; set; }

        [Required]
        [DisplayName("Event Date")]
        public DateOnly EventDate { get; set; }

        [Required]
        [DisplayName("Event Start Time")]
        public TimeOnly EventStartTime { get; set; }

        [Required]
        [DisplayName("Event End Time")]
        public TimeOnly EventEndTime { get; set; }

        [Required]
        [DisplayName("Event Description")]
        public string EventDescription { get; set; }

        [Required]
        [DisplayName("World Record")]
        public string WorldRecord { get; set; }
    }
}
