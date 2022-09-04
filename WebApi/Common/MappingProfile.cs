using AutoMapper;
using WebApi.Application.MovieOperations.Commands;
using WebApi.Application.MovieOperations.Querys;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Movei
            CreateMap<Movie, MovieViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));

            CreateMap<Movie, MovieDetailModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));

            CreateMap<Movie, CreateMovieModel>().ReverseMap();

            CreateMap<Movie, UpdateMoveiModel>().ReverseMap();
            CreateMap<UpdateMoveiModel, Movie>().ReverseMap();

            //Genre


        }
    }
}
