namespace ECommerce.Domain.Exceptions;

public sealed class DuplicateProductNameException : DomainException
{
    public DuplicateProductNameException(string name)
        : base($"A product with the name '{name}' already exists.") { }
}