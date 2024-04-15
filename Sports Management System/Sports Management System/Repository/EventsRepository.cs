using Sports_Management_System.Data;
using Sports_Management_System.Models;
using Sports_Management_System.Repository.IRepository;

namespace Sports_Management_System.Repository
{
    public class EventsRepository : Repository<Event>, IEventsRepository
    {
        private ApplicationDbContext _db;

        public EventsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Event @event)
        {
            _db.Events.Update(@event);
        }
    }
}
