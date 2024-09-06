using watchyproject.Utility;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using watchyproject.Models;

namespace watchyproject.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext AppDbContext;
        internal DbSet<T> dbSet;
        public Repository(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
            this.dbSet = AppDbContext.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
            AppDbContext.SaveChanges();
        }

        public void AralıkSil(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public void DeleteMovie(T entity)
        {
            dbSet.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> filtre)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filtre);
            return query.FirstOrDefault();
        }


        public IEnumerable<T> All
        {
            get
            {
                IQueryable<T> query = dbSet;
                return query.ToList();
            }
        }
    }
}