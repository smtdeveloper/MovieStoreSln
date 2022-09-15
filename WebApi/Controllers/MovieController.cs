using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.MovieOperations.Commands;
using WebApi.Application.MovieOperations.Querys;
using WebApi.Application.MovieOperations.Validator;
using WebApi.DbOprations;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public MovieController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetListMovies()
        {
            GetListMovieQuery query = new GetListMovieQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            MovieDetailModel result;

            GetByIdMovieQuery query = new GetByIdMovieQuery(_context, _mapper);
            query.Id = id;

            
            result = query.Handle();
            
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateMovieModel model) 
        {
            CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
            command.Model = model;

            CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id) 
        {
            DeleteMovieCommand command = new DeleteMovieCommand(_context);
            command.Id = id;

            command.Handle();

            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateMoveiModel model) 
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_context, _mapper);

            command.MovieId = id;
            
            command.Model = model;
            
            UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();

        }

    }
}
