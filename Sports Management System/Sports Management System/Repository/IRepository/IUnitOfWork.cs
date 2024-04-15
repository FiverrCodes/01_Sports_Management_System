namespace Sports_Management_System.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IGamesRepository Game { get; }
        IEventsRepository Event { get; }
        ICompetitorsRepository Competitor { get; }
        ICompetitorGamesRepository CompetitorGame { get; }
        ICompetitorEventsRepository CompetitorEvent { get; }
        void Save();
    }
}
