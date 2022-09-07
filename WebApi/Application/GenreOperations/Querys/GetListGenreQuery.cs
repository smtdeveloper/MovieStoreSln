using AutoMapper;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Querys
{
    public class GetListGenreQuery
    {
        public GetListModel Model { get; set; }

        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public GetListGenreQuery(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public List<GetListModel> Handle()
        {
            var genres = _movieStoreDbContext.Genres.Where(x => x.IsActive == true).ToList<Genre>();

            var mapModel = _mapper.Map<List<GetListModel>>(genres);

            return mapModel;

        }


    }

    public class GetListModel
    {
        public string Name { get; set; }

    }
}
