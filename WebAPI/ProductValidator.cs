using FluentValidation;

namespace WebAPI
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty()
                .WithErrorCode("name_required")
                .WithMessage("Product name cannot be empty");

            RuleFor(p => p.Quantity).GreaterThan(0)
                .WithErrorCode("quantity_invalid")
                .WithMessage("Quantity must be greater than 0");
        }
    }
}
