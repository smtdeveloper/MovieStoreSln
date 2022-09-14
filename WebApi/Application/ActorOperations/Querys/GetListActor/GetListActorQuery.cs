using AutoMapper;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperations.Querys.GetListActor
{
    public class GetListActorQuery
    {
        public GetListActorModel Model { get; set; }

        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public GetListActorQuery(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public List<GetListActorModel> Handle()
        {
            var actors = _movieStoreDbContext.Actors.Where(x => x.IsAvtive == true).ToList<Actor>();

            var mapModel = _mapper.Map<List<GetListActorModel>>(actors);

            return mapModel;

        }


    }

    public class GetListActorModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PlayedMovies { get; set; }

    }
}
