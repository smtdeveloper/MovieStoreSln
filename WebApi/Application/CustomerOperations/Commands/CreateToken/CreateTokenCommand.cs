using AutoMapper;
using WebApi.Application.TokenOperations;
using WebApi.Application.TokenOperations.Models;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.CustomerOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model;

        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CreateTokenCommand(IMovieStoreDbContext movieStoreDbContext, IMapper mapper, IConfiguration configuration)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var customer = _movieStoreDbContext.Customers.FirstOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
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
                throw new InvalidOperationException("Email veya Şifre Hatalı !");
            }
        }

    }

    public class CreateTokenModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

}
