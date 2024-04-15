using Sports_Management_System.Data;
using Sports_Management_System.Models;
using Sports_Management_System.Repository.IRepository;

namespace Sports_Management_System.Repository
{
    public class CompetitorEventsRepository : Repository<CompetitorEvent>, ICompetitorEventsRepository
    {
        private ApplicationDbContext _db;

        public CompetitorEventsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(CompetitorEvent competitorEvent)
        {
            _db.CompetitorEvents.Update(competitorEvent);
        }
    }
}
