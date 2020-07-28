using FluentValidation;

namespace ShoppingApp.API.Orders.Validators
{
    public class UpdateOrderProductRequestValidator : AbstractValidator<UpdateOrderProductRequest>
    {
        public UpdateOrderProductRequestValidator()
        {
            RuleFor(x => x.Purchased).NotNull().WithMessage("Purchased must not be empty.");
        }
    }
}
