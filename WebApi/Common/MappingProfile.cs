using AutoMapper;
using WebApi.Application.GenreOperations.Commands;
using WebApi.Application.GenreOperations.Querys;
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

           
            CreateMap<UpdateMoveiModel, Movie>().ReverseMap();

            //Genre

            CreateMap<Genre , GetListModel>().ReverseMap();
            
            CreateMap<Genre, GenreDetailModel>().ReverseMap();
           

            CreateMap<CreateGenreModel, Genre >().ReverseMap();

            CreateMap<UpdateGenreModel, Genre >().ReverseMap();


        }
    }
}
