namespace Sports_Management_System.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IGamesRepository Game { get; }
        ICompetitorsRepository Competitor { get; }
        ICompetitorGamesRepository CompetitorGame { get; }
        void Save();
    }
}
