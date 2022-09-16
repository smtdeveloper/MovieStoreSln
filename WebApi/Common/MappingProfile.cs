using AutoMapper;
using WebApi.Application.ActorOperations.Commands.CreateActor;
using WebApi.Application.ActorOperations.Querys.GetListActor;
using WebApi.Application.CustomerOperations.Commands.CreateCustomer;
using WebApi.Application.DirectorOperations.Commands.CreateDirector;
using WebApi.Application.DirectorOperations.Commands.UpdateDirector;
using WebApi.Application.DirectorOperations.Queries.GetByIdDirector;
using WebApi.Application.DirectorOperations.Queries.GetListDirector;
using WebApi.Application.GenreOperations.Commands;
using WebApi.Application.GenreOperations.Querys;
using WebApi.Application.MovieOperations.Commands;
using WebApi.Application.MovieOperations.Querys;
using WebApi.Application.OrderOperations.Model;
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

            //Customer 
            CreateMap<Customer, CreateCustomerModel>().ReverseMap();

            //Actor
            CreateMap<Actor, CreateActorModel>().ReverseMap();

            CreateMap<Actor, GetListActorModel>().ReverseMap();


            //Director
            CreateMap<Director, CreateDirectorModel>().ReverseMap();

            CreateMap<Director, UpdateDirectorModel>().ReverseMap();

            CreateMap<Director, GetListDirectorModel>().ReverseMap();

            CreateMap<Director, GetByIdDirectorModel>().ReverseMap();


            //Order
            CreateMap<CreateOrderModel, Order>().ReverseMap();
            CreateMap<UpdateOrderModel, Order>().ReverseMap();

            CreateMap<Customer, OrderViewModel>()
                .ForMember(dest => dest.NameSurname, opt => opt.MapFrom(m => m.Name + " " + m.LastName))
                .ForMember(dest => dest.Movies, opt => opt.MapFrom(m => m.Orders.Select(s => s.Movie.Title)))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(m => m.Orders.Select(s => s.Movie.Price)))
                .ForMember(dest => dest.PurchasedDate, opt => opt.MapFrom(m => m.Orders.Select(s => s.purchasedTime)));




        }
    }
}
