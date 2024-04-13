namespace Sports_Management_System.Models.ViewModels
{
    public class CompetitorVm
    {
        public Competitor Competitor { get; set; }
        public List<Guid> SelectedGameIds { get; set; }
    }
}
