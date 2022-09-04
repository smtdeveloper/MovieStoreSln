using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOprations;

namespace WebApi.Application.MovieOperations.Querys
{
    public class GetByIdMovieQuery
    {
        public int Id { get; set; }

        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public GetByIdMovieQuery(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public MovieDetailModel Handle()
        {
            var movie = _movieStoreDbContext.Movies.Include(x => x.Genre)
                    .SingleOrDefault(x => x.ID == Id && x.IsActive == true);

            if (movie == null)
                throw new InvalidOperationException("Film Bulunamadı !");

            MovieDetailModel model = _mapper.Map<MovieDetailModel>(movie);

            return model;
        }

    }

    public class MovieDetailModel
    {
        public string Genre { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Director { get; set; }
        public string Players { get; set; }
        public int Price { get; set; }
    }

}
