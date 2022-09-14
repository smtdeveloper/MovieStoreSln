using AutoMapper;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.DirectorOperations.Queries.GetListDirector
{
    public class GetListDirectorQuery
    {
        public GetListDirectorModel Model { get; set; }

        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public GetListDirectorQuery(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public List<GetListDirectorModel> Handle()
        {
            var directors = _movieStoreDbContext.Directors.Where(x => x.IsActive == true).ToList<Director>();

            var mapModel = _mapper.Map<List<GetListDirectorModel>>(directors);

            return mapModel;

        }


    }

    public class GetListDirectorModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FilmsDirected { get; set; }

    }
}
