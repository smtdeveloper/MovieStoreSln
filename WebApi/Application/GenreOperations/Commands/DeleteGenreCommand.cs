using WebApi.DbOprations;

namespace WebApi.Application.GenreOperations.Commands
{
    public class DeleteGenreCommand
    {
        public int GenreID { get; set; }

        private readonly IMovieStoreDbContext _movieStoreDbContext;

        public DeleteGenreCommand(IMovieStoreDbContext movieStoreDbContext)
        {
            _movieStoreDbContext = movieStoreDbContext;
        }

        public void Handle()
        {
            var genre = _movieStoreDbContext.Genres.SingleOrDefault(m => m.ID == GenreID);

            if (genre == null)
                throw new InvalidOperationException("Film türü  Bulunamadı ! ");

            _movieStoreDbContext.Genres.Remove(genre);
            _movieStoreDbContext.SaveChanges();



        }

    }
}
