using WebApi.DbOprations;

namespace WebApi.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        public int DirectorId { get; set; }

        private readonly IMovieStoreDbContext _movieStoreDbContext;


        public DeleteDirectorCommand(IMovieStoreDbContext movieStoreDbContext)
        {
            _movieStoreDbContext = movieStoreDbContext;

        }
        public void Handle()
        {
            var director = _movieStoreDbContext.Directors.SingleOrDefault(m => m.Id == DirectorId);

            if (director == null)
                throw new InvalidOperationException("Yönetmen Bulunamadı ! ");

            _movieStoreDbContext.Directors.Remove(director);
            _movieStoreDbContext.SaveChanges();



        }
    }
}