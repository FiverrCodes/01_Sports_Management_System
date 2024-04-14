using System.Linq.Expressions;

namespace Sports_Management_System.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T Get(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll();
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
        void Add(T entity);
    }
}
