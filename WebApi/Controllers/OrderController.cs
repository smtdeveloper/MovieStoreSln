using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.OrderOperations.Commands.CreateOrder;
using WebApi.Application.OrderOperations.Commands.DeleteOrder;
using WebApi.Application.OrderOperations.Commands.UpdateOrder;
using WebApi.Application.OrderOperations.Model;
using WebApi.Application.OrderOperations.Queries.GetByIdOrder;
using WebApi.Application.OrderOperations.Queries.GetListOrder;
using WebApi.DbOprations;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public OrderController(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetLists()
        {
            GetListOrderQuery query = new GetListOrderQuery(_dbContext, _mapper);
            var response = query.Handle();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetDetail(int id)
        {
            GetByIdOrderQuery query = new GetByIdOrderQuery(_dbContext, _mapper);
            query.OrderId = id;

            
            var response = query.Handle();

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateOrderModel model)
        {
            CreateOrderCommand command = new CreateOrderCommand(_dbContext, _mapper);
            command.Model = model;

          
            command.Handle();

            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult Update([FromBody] UpdateOrderModel model, int Id)
        {
            UpdateOrderCommand command = new UpdateOrderCommand(_dbContext, _mapper);
            command.Model = model;
            command.OrderId = Id;
            
            command.Handle();

            return Ok();
        }

        [HttpPut("softDelete/{Id}")]
        public IActionResult SoftDelete([FromRoute] int Id)
        {
            SoftDeleteOrderCommand command = new SoftDeleteOrderCommand(_dbContext);

            command.OrderId = Id;
            command.Handle();

            return Ok();
        }
    }
}
