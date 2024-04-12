using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sports_Management_System.Models.ViewModels
{
    public class CompetitorVm
    {
        public Competitor Competitor { get; set; }

        public Guid[] GameIds { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> GamesList { get; set; }
    }
}
