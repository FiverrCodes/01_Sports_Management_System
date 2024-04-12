using Sports_Management_System.Models;

namespace Sports_Management_System.Repository.IRepository
{
    public interface ICompetitorGamesRepository : IRepository<CompetitorGame>
    {
        void Update(CompetitorGame competitorGame);
    }
}
