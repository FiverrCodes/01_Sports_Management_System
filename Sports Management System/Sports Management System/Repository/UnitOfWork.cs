using Sports_Management_System.Data;
using Sports_Management_System.Repository.IRepository;

namespace Sports_Management_System.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IGamesRepository Game { get; private set; }
        public IEventsRepository Event { get; private set; }
        public ICompetitorsRepository Competitor { get; private set; }
        public ICompetitorGamesRepository CompetitorGame { get; private set; }
        public ICompetitorEventsRepository CompetitorEvent { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Game = new GamesRepository(_db);
            Event = new EventsRepository(_db);
            Competitor = new CompetitorsRepository(_db);
            CompetitorGame = new CompetitorGamesRepository(_db);
            CompetitorEvent = new CompetitorEventsRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
