using Sports_Management_System.Data;
using Sports_Management_System.Models;
using Sports_Management_System.Repository.IRepository;

namespace Sports_Management_System.Repository
{
    public class CompetitorGamesRepository : Repository<CompetitorGame>, ICompetitorGamesRepository
    {
        private readonly ApplicationDbContext _db;

        public CompetitorGamesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(CompetitorGame competitorGame)
        {
            _db.CompetitorGames.Update(competitorGame);
        }
    }
}
