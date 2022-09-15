using WebApi.Application.TokenOperations;
using WebApi.Application.TokenOperations.Models;
using WebApi.DbOprations;

namespace WebApi.Application.CustomerOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string RefrehToken;

        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IConfiguration _configuration;

        public RefreshTokenCommand(IMovieStoreDbContext movieStoreDbContext, IConfiguration configuration)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var customer = _movieStoreDbContext.Customers.FirstOrDefault(x => x.RefreshToken == RefrehToken && x.RefreshTokenExpireDate > DateTime.Now);
            if (customer != null)
            {

                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(customer);

                customer.RefreshToken = token.RefreshToken;
                customer.RefreshTokenExpireDate = token.Experation.AddMinutes(5);

                _movieStoreDbContext.SaveChanges();
                return token;

            }
            else
            {
                throw new InvalidOperationException("Valid bir refresh token bulunamadı !");
            }
        }

    }
}
