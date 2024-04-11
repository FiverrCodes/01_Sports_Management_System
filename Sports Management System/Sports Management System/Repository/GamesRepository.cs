using Sports_Management_System.Data;
using Sports_Management_System.Models;
using Sports_Management_System.Repository.IRepository;

namespace Sports_Management_System.Repository
{
    public class GamesRepository : Repository<Game>, IGamesRepository
    {
        private ApplicationDbContext _db;

        public GamesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Game game)
        {
            _db.Games.Update(game);
        }
    }
}
