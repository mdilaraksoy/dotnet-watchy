using Microsoft.EntityFrameworkCore;
using System;
using watchyproject.Utility;

namespace watchyproject.Models
{
    public interface IMoviesRepository : IRepository<MoviesModel>
    {
        void Guncelle(MoviesModel movies);
        void Save();

        public IEnumerable<MoviesModel> GetAllMovies(AppDbContext appDbContext)
        {
            return appDbContext.Movies.ToList(); // database veri cekme
        }

    }
}
