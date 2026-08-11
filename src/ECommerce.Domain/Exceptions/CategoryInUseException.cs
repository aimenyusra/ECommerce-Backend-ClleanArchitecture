using ECommerce.Domain.Exceptions;

public sealed class CategoryInUseException : DomainException
{
    public CategoryInUseException(int categoryId)
        : base($"Category with Id '{categoryId}' cannot be deleted because it still has products assigned to it.") { }
}