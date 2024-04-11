using Sports_Management_System.Models;

namespace Sports_Management_System.Repository.IRepository
{
    public interface IGamesRepository : IRepository<Game>
    {
        void Update(Game game);
    }
}
