namespace Sports_Management_System.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IGamesRepository Game { get; }

        void Save();
    }
}
