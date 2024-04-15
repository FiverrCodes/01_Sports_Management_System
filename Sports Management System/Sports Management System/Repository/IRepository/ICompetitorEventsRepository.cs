using Sports_Management_System.Models;

namespace Sports_Management_System.Repository.IRepository
{
    public interface ICompetitorEventsRepository : IRepository<CompetitorEvent>
    {
        void Update(CompetitorEvent competitorEvent);
    }
}
