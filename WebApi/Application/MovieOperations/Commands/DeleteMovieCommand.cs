using AutoMapper;
using WebApi.DbOprations;

namespace WebApi.Application.MovieOperations.Commands
{
    public class DeleteMovieCommand
    {
        public int Id { get; set; }

        private readonly IMovieStoreDbContext _movieStoreDbContext;
        

        public DeleteMovieCommand(IMovieStoreDbContext movieStoreDbContext)
        {
            _movieStoreDbContext = movieStoreDbContext;
           
        }
        public void Handle() 
        {
            var movie = _movieStoreDbContext.Movies.SingleOrDefault(m => m.ID == Id);

            if (movie == null)
                throw new InvalidOperationException("Film Bulunamadı ! ");

            _movieStoreDbContext.Movies.Remove(movie);
            _movieStoreDbContext.SaveChanges();



        }
    }
}
