using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Application.OrderOperations.Model;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.OrderOperations.Queries.GetByIdOrder
{
    public class GetByIdOrderQuery
    {

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int OrderId;

        public GetByIdOrderQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public OrderViewModel Handle()
        {
            Customer customer = _dbContext.Customers.Include(i => i.Orders).ThenInclude(t => t.Movie).SingleOrDefault(s => s.Id == OrderId);
            OrderViewModel vm = _mapper.Map<OrderViewModel>(customer);

            return vm;
        }
    }


}
