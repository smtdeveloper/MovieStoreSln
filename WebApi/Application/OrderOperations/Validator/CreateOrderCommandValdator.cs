using FluentValidation;
using WebApi.Application.OrderOperations.Commands.CreateOrder;

namespace WebApi.Application.OrderOperations.Validator
{
    public class CreateOrderCommandValdator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValdator()
        {
            RuleFor(o => o.Model.MovieId).NotEmpty();
            RuleFor(o => o.Model.CustomerId).NotEmpty();
           
        }
    }
}
