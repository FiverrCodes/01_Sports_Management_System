namespace Sports_Management_System.Models.ViewModels
{
    public class EventBaseVm
    {
        public Guid Id { get; set; }
        public string Game { get; set; }
        public string FeatureEvent { get; set; }
        public string EventVenue { get; set; }
        public DateOnly EventDate { get; set; }
        public TimeOnly EventStartTime { get; set; }
        public TimeOnly EventEndTime { get; set; }
    }
}
