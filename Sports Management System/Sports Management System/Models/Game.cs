using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sports_Management_System.Models
{
    public class Game
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Game Code")]
        [MaxLength(7)]
        [MinLength(7)]
        [RegularExpression("(^[A-Z]{4}\\d{3}$)", ErrorMessage = "Code must be with four uppercase and three numerals!")]
        public string Code { get; set; }

        [Required]
        [DisplayName("Game Name")]
        public string Name { get; set; }

        [DisplayName("Duration In Hours")]
        public double? DurationInHours { get; set; }

        public string? Description { get; set; }

        [ValidateNever]
        public ICollection<CompetitorGame> CompetitorGames { get; set; }
    }
}
