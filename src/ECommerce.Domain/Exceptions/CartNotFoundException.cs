using ECommerce.Domain.Exceptions;

public sealed class CartNotFoundException : DomainException
{
    public CartNotFoundException(Guid customerId)
        : base($"No cart was found for customer '{customerId}'.") { }
}