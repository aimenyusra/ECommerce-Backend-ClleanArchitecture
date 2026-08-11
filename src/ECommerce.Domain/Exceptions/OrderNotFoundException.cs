using ECommerce.Domain.Exceptions;

public sealed class OrderNotFoundException : DomainException
{
    public OrderNotFoundException(int orderId)
        : base($"Order with Id '{orderId}' was not found.") { }
}