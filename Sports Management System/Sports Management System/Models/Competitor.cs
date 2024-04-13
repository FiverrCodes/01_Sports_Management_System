using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sports_Management_System.Models
{
    public class Competitor
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FName { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public DateOnly DOB { get; set; }

        [Required]
        public string Country { get; set; }

        public string? Bio { get; set; }

        [ValidateNever]
        public ICollection<CompetitorGame> CompetitorGames { get; set; }
    }
}
