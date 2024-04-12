using Sports_Management_System.Models;

namespace Sports_Management_System.Repository.IRepository
{
    public interface ICompetitorsRepository : IRepository<Competitor>
    {
        void Update(Competitor competitor);
    }
}
