using FluentValidation;
using WebApi.Application.CustomerOperations.Commands.CreateCustomer;

namespace WebApi.Application.CustomerOperations.Validator
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(c => c.Model.Name).NotEmpty();
            RuleFor(c => c.Model.LastName).NotEmpty();
            RuleFor(c => c.Model.Email).NotEmpty();
            RuleFor(c => c.Model.Password).NotEmpty();
        }
    }
}
