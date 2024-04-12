using System.ComponentModel.DataAnnotations;

namespace Sports_Management_System.Models
{
    public class CompetitorGame
    {
        [Key]
        public Guid Id { get; set; }

        public Guid GameId { get; set; }
        public Game Game { get; set; }

        public Guid CompetitorId { get; set; }
        public Competitor Competitor { get; set; }
    }
}
