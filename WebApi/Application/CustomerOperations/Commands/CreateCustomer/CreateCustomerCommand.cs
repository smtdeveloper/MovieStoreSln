using AutoMapper;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommand
    {

        public CreateCustomerModel Model { get; set; }

        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public CreateCustomerCommand(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var customer = _movieStoreDbContext.Customers.SingleOrDefault(x => x.Email == Model.Email);

            if (customer != null)
                throw new InvalidOperationException("Film zaten mevcut.");

            customer = _mapper.Map<Customer>(Model);

            _movieStoreDbContext.Customers.Add(customer);
            _movieStoreDbContext.SaveChanges();
        }

    }

    public class CreateCustomerModel
    {
       
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

}
