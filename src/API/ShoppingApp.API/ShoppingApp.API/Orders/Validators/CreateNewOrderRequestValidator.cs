using FluentValidation;
using ShoppingApp.API.Orders.Requests;

namespace ShoppingApp.API.Orders.Validators
{
    public class CreateNewOrderRequestValidator : AbstractValidator<CreateNewOrderRequest>
    {
        public CreateNewOrderRequestValidator()
        {
            RuleFor(x => x.OrderName).NotNull().NotEmpty().WithMessage("OrderName must not be empty.");
        }
    }
}
