using FluentValidation;
using ShoppingApp.API.Orders.Requests;

namespace ShoppingApp.API.Orders.Validators
{
    public class AddNewOrderProductRequestValidator : AbstractValidator<AddNewOrderProductRequest>
    {
        public AddNewOrderProductRequestValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty()
                .NotNull()
                .WithMessage("ProductId must not be null.");
        }
    }
}
