using watchyproject.Models;
using watchyproject.Utility;

namespace watchyproject.Models
{
    public class MoviesRepository : Repository<MoviesModel>, IMoviesRepository
    {
        private AppDbContext _appDbContext;
        public MoviesRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Guncelle(MoviesModel mvm)
        {
            _appDbContext.Update(mvm);
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }

    }
}