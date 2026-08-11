using ECommerce.Domain.Exceptions;

public sealed class DuplicateCategoryNameException : DomainException
{
    public DuplicateCategoryNameException(string name)
        : base($"A category with the name '{name}' already exists.") { }
}