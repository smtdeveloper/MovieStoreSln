using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Application.OrderOperations.Model;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.OrderOperations.Queries.GetListOrder
{
    public class GetListOrderQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetListOrderQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public List<OrderViewModel> Handle()
        {
            List<Customer> list = _dbContext.Customers.Include(i => i.Orders).ThenInclude(t => t.Movie).Where(w => w.Orders.Any(a => a.IsActive)).OrderBy(x => x.Id).ToList();
            List<OrderViewModel> vm = _mapper.Map<List<OrderViewModel>>(list);

            return vm;
        }
    }
}
