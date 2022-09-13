using AutoMapper;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.MovieOperations.Commands
{
    public class UpdateMovieCommand
    {
        public UpdateMoveiModel Model { get; set; }
        public int MovieId { get; set; }

        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public UpdateMovieCommand(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public void Handle() 
        {
            var movie = _movieStoreDbContext.Movies.SingleOrDefault(x => x.ID == MovieId);

            if (movie == null) 
            {
                throw new InvalidOperationException("Film Bulunamadı !");
            }
             

            _mapper.Map<UpdateMoveiModel, Movie>(Model, movie);

            _movieStoreDbContext.Movies.Update(movie);
            _movieStoreDbContext.SaveChanges();
        }

    }

   public class UpdateMoveiModel
    {
        public int GenreID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public int Price { get; set; }
        public bool IsActive { get; set; }

    }
}
