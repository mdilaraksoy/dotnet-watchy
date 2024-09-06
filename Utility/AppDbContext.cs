using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using watchyproject.Models;


namespace watchyproject.Utility
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options) { }

        public DbSet<LoginViewModel> LoginInfos { get; set; }

        public DbSet<MoviesModel> Movies { get; set; }
        
    }
}
