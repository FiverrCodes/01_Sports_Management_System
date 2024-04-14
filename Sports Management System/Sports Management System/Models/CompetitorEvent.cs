namespace Sports_Management_System.Models
{
    public class CompetitorEvent
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; }
        public Guid CompetitorId { get; set; }
        public Competitor Competitor { get; set; }
        public string CompetitorPosition { get; set; }
        public string CompetitorMedal { get; set; }
    }
}
