using AutoMapper;
using WebApi.DbOprations;

namespace WebApi.Application.DirectorOperations.Queries.GetByIdDirector
{
    public class GetByIdDirectorQuery
    {
        public int DirectorId { get; set; }


        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public GetByIdDirectorQuery(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public GetByIdDirectorModel Handle()
        {
            var director = _movieStoreDbContext.Directors.SingleOrDefault(g => g.Id == DirectorId);

            if (director == null)
            {
                throw new InvalidOperationException("Yönetmen  bulunamadı ! ");
            }

            var model = _mapper.Map<GetByIdDirectorModel>(director);

            return model;



        }


    }

    public class GetByIdDirectorModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FilmsDirected { get; set; }

    }
}

