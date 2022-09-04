using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOprations
{
    public interface IMovieStoreDbContext
    {
        DbSet<Movie> Movies { get; set; }
        DbSet<Genre> Genres { get; set; }

        int SaveChanges();
    }
}
