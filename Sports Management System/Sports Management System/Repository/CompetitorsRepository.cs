using Sports_Management_System.Data;
using Sports_Management_System.Models;
using Sports_Management_System.Repository.IRepository;

namespace Sports_Management_System.Repository
{
    public class CompetitorsRepository : Repository<Competitor>, ICompetitorsRepository
    {
        private readonly ApplicationDbContext _db;
        public CompetitorsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Competitor competitor)
        {
            _db.Competitors.Update(competitor);
        }
    }
}
