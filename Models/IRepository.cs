using System.Linq.Expressions;

namespace watchyproject.Models
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> All { get; }

        T Get(Expression<Func<T, bool>> filtre);
        void Add(T entity);
        void DeleteMovie(T entity);
        void AralıkSil(IEnumerable<T> entities);

    }
}
