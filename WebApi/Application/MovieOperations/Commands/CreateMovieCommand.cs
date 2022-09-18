using AutoMapper;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.MovieOperations.Commands;

    public class CreateMovieCommand
    {
        public CreateMovieModel Model { get; set; }
   
        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public CreateMovieCommand(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public void Handle() 
        {
            var movie = _movieStoreDbContext.Movies.SingleOrDefault(x => x.Title == Model.Title);

            if (movie != null)
                throw new InvalidOperationException("Film zaten mevcut.");

            movie = _mapper.Map<Movie>(Model);

            _movieStoreDbContext.Movies.Add(movie);
            _movieStoreDbContext.SaveChanges();
        }

    }

    public class CreateMovieModel 
    {
        public int GenreID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public int Price { get; set; }
    }


