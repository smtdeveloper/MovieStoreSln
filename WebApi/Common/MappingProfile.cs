using AutoMapper;
using WebApi.Application.MovieOperations.Querys;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieViewModel>();
        }
    }
}
