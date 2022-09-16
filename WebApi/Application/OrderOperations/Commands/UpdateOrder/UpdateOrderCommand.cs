using AutoMapper;
using WebApi.Application.OrderOperations.Model;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.OrderOperations.Commands.UpdateOrder
{
    public class UpdateOrderCommand
    {
        public UpdateOrderModel Model { get; set; }
        public int OrderId;


        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
       
       
        public UpdateOrderCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            Customer customer = _dbContext.Customers.SingleOrDefault(s => s.Id == Model.CustomerId);
            Movie movies = _dbContext.Movies.SingleOrDefault(s => s.ID == Model.MovieId);
           
            Order order = _dbContext.Orders.SingleOrDefault(s => s.Id == OrderId);

            if (customer is null)
                throw new InvalidOperationException("Müşteri bulunamadı!");
            else if (movies is null)
                throw new InvalidOperationException("Film bulunamadı!");
            else if (order is null)
                throw new InvalidOperationException("ilgili kayda ait veri bulunamadı.");
                
            _mapper.Map<UpdateOrderModel, Order>(Model, order);

            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
        }
    }

}