using ECommerce.Application.Common.Interfaces;
using ECommerce.Application.Common.Messaging;
using ECommerce.Domain.Exceptions;
using ECommerce.Domain.ValueObjects;

namespace ECommerce.Application.Products.Commands.UpdateProduct;

public sealed class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.Id, cancellationToken);
        if (product is null)
            throw new ProductNotFoundException(request.Id);

        var category = await _unitOfWork.Categories.GetByIdAsync(request.CategoryId, cancellationToken);
        if (category is null)
            throw new CategoryNotFoundException(request.CategoryId);

        if (!string.Equals(request.Name, product.Name, StringComparison.Ordinal))
        {
            var nameExists = await _unitOfWork.Products.NameExistsAsync(request.Name, cancellationToken);
            if (nameExists)
                throw new DuplicateProductNameException(request.Name);
        }

        product.UpdateDetails(request.Name, request.Description);
        product.UpdateCategory(request.CategoryId);
        product.UpdatePrice(Money.Create(request.Price, request.Currency));
        product.SetStock(request.StockQuantity);

        _unitOfWork.Products.Update(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}