﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.MovieOperations.Querys
{
    public class GetMovieQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMovieQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public List<MovieViewModel> Handle()
        {
            var movies = _dbContext.Movies.Where(x => x.IsActive == true).OrderBy(x => x.ID).ToList<Movie>();

            List<MovieViewModel> model = _mapper.Map<List<MovieViewModel>>(movies);
            return model;
        }

    }


    public class MovieViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Price { get; set; }

    }

}
