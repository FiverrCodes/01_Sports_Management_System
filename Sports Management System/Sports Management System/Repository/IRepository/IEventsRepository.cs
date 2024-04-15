using Sports_Management_System.Models;

namespace Sports_Management_System.Repository.IRepository
{
    public interface IEventsRepository : IRepository<Event>
    {
        void Update(Event @event);
    }
}
