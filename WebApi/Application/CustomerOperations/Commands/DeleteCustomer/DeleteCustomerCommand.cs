using WebApi.DbOprations;

namespace WebApi.Application.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand
    {
        public int CustomerId { get; set; }

        private readonly IMovieStoreDbContext _movieStoreDbContext;


        public DeleteCustomerCommand(IMovieStoreDbContext movieStoreDbContext)
        {
            _movieStoreDbContext = movieStoreDbContext;

        }
        public void Handle()
        {
            var customer = _movieStoreDbContext.Customers.SingleOrDefault(m => m.Id == CustomerId);

            if (customer == null)
                throw new InvalidOperationException("Müsteri Bulunamadı ! ");

            _movieStoreDbContext.Customers.Remove(customer);
            _movieStoreDbContext.SaveChanges();



        }
    }
}
