using FluentValidation;

namespace ECommerce.Application.Orders.Commands.PlaceOrder;

public sealed class PlaceOrderCommandValidator : AbstractValidator<PlaceOrderCommand>
{
    public PlaceOrderCommandValidator()
    {
        RuleFor(x => x.ShippingAddress).NotNull();

        When(x => x.ShippingAddress is not null, () =>
        {
            RuleFor(x => x.ShippingAddress.Street).NotEmpty();
            RuleFor(x => x.ShippingAddress.City).NotEmpty();
            RuleFor(x => x.ShippingAddress.PostalCode).NotEmpty();
            RuleFor(x => x.ShippingAddress.Country).NotEmpty();
        });
    }
}