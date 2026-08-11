using ECommerce.Application.Common.Interfaces;
using ECommerce.Application.Common.Messaging;
using ECommerce.Domain.Exceptions;
using DomainCart = ECommerce.Domain.Entities.Cart;

namespace ECommerce.Application.Cart.Commands.AddItemToCart;

public sealed class AddItemToCartCommandHandler : ICommandHandler<AddItemToCartCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddItemToCartCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.ProductId, cancellationToken);
        if (product is null)
            throw new ProductNotFoundException(request.ProductId);

        if (request.Quantity > product.StockQuantity)
            throw new InsufficientStockException(product.Name, product.StockQuantity, request.Quantity);

        var cart = await _unitOfWork.Carts.GetByCustomerIdAsync(request.CustomerId, cancellationToken);

        if (cart is null)
        {
            cart = DomainCart.Create(request.CustomerId);
            cart.AddItem(request.ProductId, product.Price, request.Quantity);
            await _unitOfWork.Carts.AddAsync(cart, cancellationToken);
        }
        else
        {
            cart.AddItem(request.ProductId, product.Price, request.Quantity);
            _unitOfWork.Carts.Update(cart);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}