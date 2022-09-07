using AutoMapper;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model { get; set; }

        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public CreateGenreCommand(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var genre = _movieStoreDbContext.Genres.SingleOrDefault(x => x.Name == Model.Name);

            if (genre != null)
                throw new InvalidOperationException("Film Türü zaten mevcut.");

            genre = _mapper.Map<Genre>(Model);

            _movieStoreDbContext.Genres.Add(genre);
            _movieStoreDbContext.SaveChanges();
        }

    }

    public class CreateGenreModel
    {
        public string Name { get; set; }
    }

}
