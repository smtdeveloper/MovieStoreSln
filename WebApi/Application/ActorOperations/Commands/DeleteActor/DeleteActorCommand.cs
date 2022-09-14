using WebApi.DbOprations;

namespace WebApi.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommand
    {

        public int ActorId { get; set; }

        private readonly IMovieStoreDbContext _movieStoreDbContext;


        public DeleteActorCommand(IMovieStoreDbContext movieStoreDbContext)
        {
            _movieStoreDbContext = movieStoreDbContext;

        }
        public void Handle()
        {
            var actor = _movieStoreDbContext.Actors.SingleOrDefault(m => m.Id == ActorId);

            if (actor == null)
                throw new InvalidOperationException("Oyuncu Bulunamadı ! ");

            _movieStoreDbContext.Actors.Remove(actor);
            _movieStoreDbContext.SaveChanges();



        }
    }
}